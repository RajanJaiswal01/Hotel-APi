using TestHotel.Common;
using TestHotel.Entities;
using TestHotel.Repository.IRepository;

namespace TestHotel.Repository
{
    public class InvoiceRepository : RepositoryBase<Invoice>, IInvoiceRepository
    {
        public InvoiceRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
