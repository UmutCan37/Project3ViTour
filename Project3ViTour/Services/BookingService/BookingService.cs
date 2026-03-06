using AutoMapper;
using MongoDB.Driver;
using Project3ViTour.Dtos.BookingDtos;
using Project3ViTour.Entities;
using Project3ViTour.Settings;

namespace Project3ViTour.Services.BookingService
{
    public class BookingService : IBookingService
    {
        private readonly IMapper _mapper;
        private readonly IMongoCollection<Booking> _bookingCollection;
        public BookingService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            _mapper = mapper;
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _bookingCollection = database.GetCollection<Booking>(_databaseSettings.BookingCollectionName);
        }
        public async Task CreateBookingAsync(CreateBookingDto createBookingDto)
        {
            var value=_mapper.Map<Booking>(createBookingDto);
            await _bookingCollection.InsertOneAsync(value);
        }

        public async Task DeleteBookingAsync(string id)
        {
            await _bookingCollection.DeleteOneAsync(x => x.BookingId == id);
        }

        public async Task<List<ResultBookingDto>> GetAllBookingAsync()
        {
            var value=await _bookingCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultBookingDto>>(value);
        }

        public async Task<GetBookingByIdDto> GetBookingByIdAsync(string id)
        {
            var value= await _bookingCollection.Find(x => x.BookingId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetBookingByIdDto>(value);
        }

        public async Task UpdateBookingAsync(UpdateBookingDto updateBookingDto)
        {
            var value=_mapper.Map<Booking>(updateBookingDto);
            await _bookingCollection.FindOneAndReplaceAsync(x => x.BookingId == updateBookingDto.BookingId, value);
        }

        public async Task<List<ResultBookingDto>> GetBookingsByTourIdAsync(string tourId)
        {
            var value = await _bookingCollection.Find(x => x.TourId == tourId).ToListAsync();
            return _mapper.Map<List<ResultBookingDto>>(value);
        }

        public async Task<int> GetTotalGuestCountByTourIdAsync(string tourId)
        {
            var value=await _bookingCollection.Find(x => x.TourId == tourId && x.IsStatus==true).ToListAsync();
            return value.Sum(x => x.GuestCount);
        }
    }
}
