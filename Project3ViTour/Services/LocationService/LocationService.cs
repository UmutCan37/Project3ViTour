using AutoMapper;
using MongoDB.Driver;
using Project3ViTour.Dtos.LocationDtos;
using Project3ViTour.Entities;
using Project3ViTour.Settings;

namespace Project3ViTour.Services.LocationService
{
    public class LocationService : ILocationService
    {
        private readonly IMapper _mapper;
        private readonly IMongoCollection<Location> _locationCollection;

        public LocationService(IDatabaseSettings databaseSettings, IMapper mapper)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _locationCollection = database.GetCollection<Location>(databaseSettings.LocationCollectionName);
            _mapper = mapper;
        }

        public async Task CreateLocationAsync(CreateLocationDto createLocationDto)
        {
            var values =_mapper.Map<Location>(createLocationDto);
            await _locationCollection.InsertOneAsync(values);
        }

        public async Task DeleteLocationAsync(string id)
        {
            await _locationCollection.DeleteOneAsync(x => x.LocationId == id);

        }

        public async Task<List<ResultLocationDto>> GetAllLocationsAsync()
        {
            var values =await _locationCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultLocationDto>>(values);
        }

        public async Task<GetLocationByIdDto> GetLocationByIdAsync(string id)
        {
            var value= await _locationCollection.Find(x => x.LocationId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetLocationByIdDto>(value);
        }

        public Task UpdateLocationAsync(UpdateLocationDto updateLocationDto)
        {
            var value = _mapper.Map<Location>(updateLocationDto);
            return _locationCollection.FindOneAndReplaceAsync(x => x.LocationId == updateLocationDto.LocationId, value);
        }
    }
}
