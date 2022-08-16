using TestHotel.DTOs;
using TestHotel.Entities;

namespace TestHotel.Service.IService
{
    public interface IRoomService
    {
        IEnumerable<Room> GetAll();
        Task<Int64> Create(RoomDTO model);
        Task<Int64> Update(RoomDTO model);
        Task Delete(int id);
        Task<Room> GetById(int id);
        List<Room> GetRoomByType(string roomtype);
        Task FillterRoom();


    }
}
