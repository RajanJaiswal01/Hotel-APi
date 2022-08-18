using TestHotel.Common;
using TestHotel.Entities;
using TestHotel.Repository.IRepository;

namespace TestHotel.Repository
{
    public class BookingRepository : RepositoryBase<Booking>,IBookingRepository
    {
        public BookingRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
