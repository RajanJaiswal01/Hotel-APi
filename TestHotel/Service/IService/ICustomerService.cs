using TestHotel.DTOs;
using TestHotel.Entities;

namespace TestHotel.Service.IService
{
    public interface ICustomerService
    {
        IEnumerable<Customer> GetAll();
        Task<Customer> Create (CustomerDTO model);
        Task<Int64> Update (CustomerDTO model);
        Task Delete (int id);
        Task<Customer> GetById(int id);
        Task FilterUser();
    }
}
