
using Project3ViTour.Dtos.GalleryImageDtos;

namespace Project3ViTour.Services.GalleryImageService
{
    public interface IGalleryImageService
    {
        Task<List<ResultGalleryImageDto>> GetAllGalleryImageAsync();
        Task CreateGalleryImageAsync(CreateGalleryImageDto createGalleryImageDto);
        Task UpdateGalleryImageAsync(UpdateGalleryImageDto updateGalleryImageDto);
        Task DeleteGalleryImageAsync(string id);
        Task<GetGalleryImageByIdDto> GetGalleryImageByIdAsync(string id);
    }
}
