using Project3ViTour.Dtos.ReviewDtos;
using Project3ViTour.Dtos.TourPlanningDtos;

namespace Project3ViTour.Services.TourPlanningService
{
    public interface ITourPlanningService
    {
        Task<List<ResultTourPlanningDto>> GetAllTourPlanningAsync();
        Task CreateTourPlanningAsync(CreateTourPlanningDto createTourPlanningDto);
        Task UpdateTourPlanningAsync(UpdateTourPlanningDto updateTourPlanningDto);
        Task DeleteTourPlanningAsync(string id);
        Task<GetTourPlanningByIdDto> GetTourPlanningByIdAsync(string id);
    }
}
