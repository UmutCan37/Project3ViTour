using AutoMapper;
using MongoDB.Driver;
using Project3ViTour.Dtos.ReviewDtos;
using Project3ViTour.Dtos.TourPlanningDtos;
using Project3ViTour.Entities;
using Project3ViTour.Settings;

namespace Project3ViTour.Services.TourPlanningService
{
    
    public class TourPlanningService : ITourPlanningService
    {
        private readonly IMapper _mapper;
        private readonly IMongoCollection<TourPlanning> _tourPlanningCollection;

        public TourPlanningService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            _mapper = mapper;
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _tourPlanningCollection = database.GetCollection<TourPlanning>(_databaseSettings.TourPlanningCollectionName);
        }
        public async Task CreateTourPlanningAsync(CreateTourPlanningDto createTourPlanningDto)
        {
            var value = _mapper.Map<TourPlanning>(createTourPlanningDto);
            await _tourPlanningCollection.InsertOneAsync(value);
        }

        public async Task DeleteTourPlanningAsync(string id)
        {
            await _tourPlanningCollection.DeleteOneAsync(x => x.TourPlanningId == id);
        }

        public async Task<List<ResultTourPlanningDto>> GetAllTourPlanningAsync()
        {
            var value = await _tourPlanningCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultTourPlanningDto>>(value);
        }

        public async Task<GetTourPlanningByIdDto> GetTourPlanningByIdAsync(string id)
        {
            var value = await _tourPlanningCollection.Find(x => x.TourPlanningId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetTourPlanningByIdDto>(value);
        }

        public Task UpdateTourPlanningAsync(UpdateTourPlanningDto updateTourPlanningDto)
        {
            var value = _mapper.Map<TourPlanning>(updateTourPlanningDto);
            return _tourPlanningCollection.FindOneAndReplaceAsync(x => x.TourPlanningId == updateTourPlanningDto.TourPlanningId, value);
        }
    }
}
