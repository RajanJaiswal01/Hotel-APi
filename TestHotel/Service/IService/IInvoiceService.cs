using TestHotel.DTOs;
using TestHotel.Entities;

namespace TestHotel.Service.IService
{
    public interface IInvoiceService
    {
        IEnumerable<Invoice> GetAll();
        Task<Int64> Create(InvoiceDTO model);
        Task<Int64> Update(InvoiceDTO model);
        Task Delete(int id);
        Task<Invoice> GetById(int id);


    }
}
