using TestHotel.Common;
using TestHotel.Entities;
using TestHotel.Repository.IRepository;

namespace TestHotel.Repository
{
    public class RoomRepository : RepositoryBase<Room>, IRoomRepository
    {
        public RoomRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
