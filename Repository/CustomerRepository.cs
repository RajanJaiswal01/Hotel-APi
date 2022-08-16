using TestHotel.Common;
using TestHotel.Entities;
using TestHotel.Repository.IRepository;

namespace TestHotel.Repository
{
    public class CustomerRepository : RepositoryBase<Customer>, ICustomerRepository
    {
        public CustomerRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
