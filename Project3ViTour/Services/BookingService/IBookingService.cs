using Project3ViTour.Dtos.BookingDtos;
using Project3ViTour.Dtos.CategoryDtos;

namespace Project3ViTour.Services.BookingService
{
    public interface IBookingService
    {
        Task<List<ResultBookingDto>> GetAllBookingAsync();
        Task CreateBookingAsync(CreateBookingDto createBookingDto);
        Task UpdateBookingAsync(UpdateBookingDto updateBookingDto);
        Task DeleteBookingAsync(string id);
        Task<GetBookingByIdDto> GetBookingByIdAsync(string id);

        Task<List<ResultBookingDto>> GetBookingsByTourIdAsync(string tourId);

        Task<int> GetTotalGuestCountByTourIdAsync(string tourId);
    }
}
