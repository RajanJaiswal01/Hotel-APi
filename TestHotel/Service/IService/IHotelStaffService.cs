using TestHotel.DTOs;
using TestHotel.Entities;

namespace TestHotel.Service.IService
{
    public interface IHotelStaffService
    {
        IEnumerable<HotelStaff> GetAll();
        Task<Int64> Create(HotelStaffDTO model);
        Task<Int64> Update(HotelStaffDTO model);
        Task Delete(int id);
        Task<HotelStaff> GetById(int id);
    }
}
