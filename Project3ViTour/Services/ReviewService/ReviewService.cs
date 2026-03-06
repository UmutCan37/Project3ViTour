using AutoMapper;
using MongoDB.Driver;
using Project3ViTour.Dtos.ReviewDtos;
using Project3ViTour.Entities;
using Project3ViTour.Settings;
using System.Collections.Generic;

namespace Project3ViTour.Services.ReviewService
{

    public class ReviewService : IReviewService
    {
        private readonly IMapper _mapper;
        private readonly IMongoCollection<Review> _reviewCollection;

        public ReviewService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            _mapper = mapper;
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _reviewCollection = database.GetCollection<Review>(_databaseSettings.ReviewCollectionName);
        }

        public async Task CreateReviewAsync(CreateReviewDto createReviewDto)
        {
            var value = _mapper.Map<Review>(createReviewDto);
            await _reviewCollection.InsertOneAsync(value);
        }

        public async Task DeleteReviewAsync(string id)
        {
            await _reviewCollection.DeleteOneAsync(x => x.ReviewId == id);
        }

        public async Task<List<ResultReviewDto>> GetAllReviewsAsync()
        {
            var value = await _reviewCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultReviewDto>>(value);
        }

        public async Task<List<ResultReviewByTourIdDto>> GetAllReviewsByTourIdAsync(string id)
        {
            var value =await _reviewCollection.Find(x => x.TourId == id).ToListAsync();
            return _mapper.Map<List<ResultReviewByTourIdDto>>(value);
        }

        public async Task<double> GetAverageRatingAsync()
        {
            var result = await _reviewCollection
                        .Aggregate()
                        .Group(_ => 1, g => new
                        {
                            Avg = g.Average(x => x.Score)
                        })
                        .FirstOrDefaultAsync();

            return result?.Avg ?? 0;
        }

        public async  Task<List<ResultReviewDto>> GetLastReviewsAsync(int count)
        {
            var value = await _reviewCollection
                .Find(x => x.Status == true)            
                .SortByDescending(x => x.ReviewDate)
                .Limit(count)
                .ToListAsync();

            return _mapper.Map<List<ResultReviewDto>>(value);
        }

        public async Task<GetReviewByIdDto> GetReviewByIdAsync(string id)
        {
            var value =await _reviewCollection.Find(x => x.ReviewId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetReviewByIdDto>(value);
        }

        public async Task<int> GetReviewCountAsync()
        {
            return (int)await _reviewCollection.CountDocumentsAsync(x => x.Status == true);
        }

        public Task UpdateReviewAsync(UpdateReviewDto updateReviewDto)
        {
            var value = _mapper.Map<Review>(updateReviewDto);
            return _reviewCollection.FindOneAndReplaceAsync(x => x.ReviewId == updateReviewDto.ReviewId, value);
        }
    }
}
