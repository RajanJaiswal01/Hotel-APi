using TestHotel.DTOs;
using TestHotel.Entities;
using TestHotel.Repository;
using TestHotel.Repository.IRepository;
using TestHotel.Service.IService;
using Worklog.Repository;

namespace TestHotel.Service
{
    public class BookingService : IBookingService
        
    {
        IBookingRepository _bookingRepository;
        IUnitOfWork _unitOfWork;
        IRoomRepository _roomRepository;

        public BookingService(IBookingRepository bookingRepository, IUnitOfWork unitOfWork, IRoomRepository roomRepository)
        {
            _bookingRepository = bookingRepository;
            _unitOfWork = unitOfWork;
            _roomRepository = roomRepository;
        }

        public IEnumerable<Booking> GetAll()
        {
            var Result = _bookingRepository.GetMany();
            return Result;
        }
        public async Task<Int64> Create(BookingDTO model)
        {
            Booking booking = new Booking();
            booking.NoOfRooms = model.NoOfRooms;
            booking.CheckInDate = model.CheckInDate;
            booking.CheckOutDate = model.CheckOutDate;
            booking.Price = model.Price;
            booking.CustomerId = model.CustomerId;
            await _bookingRepository.Add(booking);
            await _unitOfWork.Commit();
            return booking.BookingId;

        }

        public async Task<Int64> Update(BookingDTO model)
        {
            Booking booking = await _bookingRepository.GetSingle(model.BookingId);

            if (booking != null)
            {
                booking.NoOfRooms = model.NoOfRooms;
                booking.CheckInDate = model.CheckInDate;
                booking.CheckOutDate = model.CheckOutDate;
                booking.Price = model.Price;
                booking.CustomerId = model.CustomerId;
                await _bookingRepository.Add(booking);
                await _unitOfWork.Commit();

            }
            return booking.BookingId;
        }

        public async Task Delete(int id)
        {
            var data = _bookingRepository.GetById(id);
            _bookingRepository.Delete(data);
            await _unitOfWork.Commit();
        }

        public async Task<Booking> GetById(int id)
        {
            return await _bookingRepository.GetSingle(id);
        }
    }
}
