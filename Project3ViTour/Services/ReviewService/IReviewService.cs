using Project3ViTour.Dtos.ReviewDtos;

namespace Project3ViTour.Services.ReviewService
{
    public interface IReviewService
    {
        Task<List<ResultReviewDto>> GetAllReviewsAsync();
        Task CreateReviewAsync(CreateReviewDto createReviewDto);
        Task UpdateReviewAsync(UpdateReviewDto updateReviewDto);
        Task DeleteReviewAsync(string id);
        Task<GetReviewByIdDto> GetReviewByIdAsync(string id);

        Task<List<ResultReviewByTourIdDto>> GetAllReviewsByTourIdAsync(string id);
        Task<int> GetReviewCountAsync();

        Task<List<ResultReviewDto>> GetLastReviewsAsync(int count);

        Task<double> GetAverageRatingAsync();

    }
}
