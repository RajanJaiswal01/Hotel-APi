using TestHotel.Common;
using TestHotel.Entities;
using TestHotel.Repository.IRepository;

namespace TestHotel.Repository
{
    public class HotelStaffRepository : RepositoryBase<HotelStaff>, IHotelStaffRepository
    {
        public HotelStaffRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
