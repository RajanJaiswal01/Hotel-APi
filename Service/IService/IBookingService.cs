using System;
using TestHotel.DTOs;
using TestHotel.Entities;

namespace TestHotel.Service.IService
{
    public interface IBookingService
    {
        IEnumerable<Booking> GetAll();
        Task<Int64> Create(BookingDTO model);
        Task<Int64> Update(BookingDTO model);
        Task Delete(int id);
        Task<Booking> GetById(int id);
       
    }
}
