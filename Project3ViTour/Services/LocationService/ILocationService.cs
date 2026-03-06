using Project3ViTour.Dtos.LocationDtos;

namespace Project3ViTour.Services.LocationService
{
    public interface ILocationService
    {
        Task<List<ResultLocationDto>> GetAllLocationsAsync();
        Task CreateLocationAsync(CreateLocationDto createLocationDto);
        Task UpdateLocationAsync(UpdateLocationDto updateLocationDto);
        Task DeleteLocationAsync(string id);
        Task<GetLocationByIdDto> GetLocationByIdAsync(string id);
    }
}
