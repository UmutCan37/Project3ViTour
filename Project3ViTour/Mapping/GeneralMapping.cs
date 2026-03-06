using AutoMapper;
using Project3ViTour.Dtos.BookingDtos;
using Project3ViTour.Dtos.CategoryDtos;
using Project3ViTour.Dtos.GalleryImageDtos;
using Project3ViTour.Dtos.LocationDtos;
using Project3ViTour.Dtos.ReviewDtos;
using Project3ViTour.Dtos.TourDtos;
using Project3ViTour.Dtos.TourPlanningDtos;
using Project3ViTour.Entities;

namespace Project3ViTour.Mapping
{
    public class GeneralMapping:Profile
    {
        public GeneralMapping() 
        { 
            CreateMap<Category, CreateCategoryDto>().ReverseMap();
            CreateMap<Category, UpdateCategoryDto>().ReverseMap();
            CreateMap<Category, ResultCategoryDto>().ReverseMap();
            CreateMap<Category, GetCatgoryByIdDto>().ReverseMap();

            CreateMap<Tour, CreateTourDto>().ReverseMap();
            CreateMap<Tour, UpdateTourDto>().ReverseMap();
            CreateMap<Tour, ResultTourDto>().ReverseMap();
            CreateMap<Tour, GetTourByIdDto>().ReverseMap();

            CreateMap<Review, CreateReviewDto>().ReverseMap();
            CreateMap<Review, UpdateReviewDto>().ReverseMap();
            CreateMap<Review, ResultReviewDto>().ReverseMap();
            CreateMap<Review, GetReviewByIdDto>().ReverseMap();
            CreateMap<Review, ResultReviewByTourIdDto>().ReverseMap();

            CreateMap<Location, CreateLocationDto>().ReverseMap();
            CreateMap<Location, UpdateLocationDto>().ReverseMap();
            CreateMap<Location, ResultLocationDto>().ReverseMap();
            CreateMap<Location, GetLocationByIdDto>().ReverseMap();

            CreateMap<GalleryImage, CreateGalleryImageDto>().ReverseMap();
            CreateMap<GalleryImage, UpdateGalleryImageDto>().ReverseMap();
            CreateMap<GalleryImage, ResultGalleryImageDto>().ReverseMap();
            CreateMap<GalleryImage, GetGalleryImageByIdDto>().ReverseMap();

            CreateMap<TourPlanning, CreateTourPlanningDto>().ReverseMap();
            CreateMap<TourPlanning, UpdateTourPlanningDto>().ReverseMap();
            CreateMap<TourPlanning, ResultTourPlanningDto>().ReverseMap();
            CreateMap<TourPlanning, GetTourPlanningByIdDto>().ReverseMap();

            CreateMap<Booking, CreateBookingDto>().ReverseMap();
            CreateMap<Booking, UpdateBookingDto>().ReverseMap();
            CreateMap<Booking, ResultBookingDto>()
            .ForMember(dest => dest.TourId, opt => opt.MapFrom(src => src.TourId))
    .        ReverseMap();
            CreateMap<Booking, GetBookingByIdDto>().ReverseMap();
        }

    }
}
