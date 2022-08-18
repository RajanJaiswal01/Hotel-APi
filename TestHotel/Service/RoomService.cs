using TestHotel.DTOs;
using TestHotel.Entities;
using TestHotel.Repository.IRepository;
using TestHotel.Service.IService;
using Worklog.Repository;

namespace TestHotel.Service
{
    public class RoomService : IRoomService
    {
        private readonly IRoomRepository _roomRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBookingRepository _bookingRepository;
        public RoomService(IRoomRepository roomRepository, IUnitOfWork unitOfWork, IBookingRepository bookingRepository)
        {
            _roomRepository = roomRepository;
            _unitOfWork = unitOfWork;
            _bookingRepository = bookingRepository;
        }
        public IEnumerable<Room> GetAll()
        {
            var result = _roomRepository.GetMany();
            return result;
        }

        public List<Room> GetRoomByType(string roomtype)
        {
            var room = _roomRepository.GetAll(x => x.TypeOfRoom == roomtype).ToList();
            return room;
        }

        public async Task<Int64> Create(RoomDTO model)
        {
            Room room = new Room();
            room.RoomId = model.RoomId;
            room.BookingId = model.BookingId;
            room.RoomNo = model.RoomNo;
            room.Occupied = model.Occupied;
            room.TypeOfRoom = model.TypeOfRoom;
            room.Price = model.Price;
            room.imagePath = model.imagePath;
            await _roomRepository.Add(room);
            await _unitOfWork.Commit();
            return room.RoomId;
        }

        public async Task<long> Update(RoomDTO model)
        {
            Room result = await _roomRepository.GetSingle(model.RoomId);
            if (result != null)
            {
                result.BookingId = model.BookingId;
                result.RoomNo = model.RoomNo;
                result.Occupied = model.Occupied;
                result.TypeOfRoom = model.TypeOfRoom;
                result.Price = model.Price;
                result.imagePath = model.imagePath;
                await _unitOfWork.Commit();
            }
            return result.RoomId;
        }

        public async Task<long> UpdateRoom(string roomNo)
        {
            var results = _roomRepository.GetAll(x => x.RoomNo == roomNo);
            Room result = await _roomRepository.GetSingle(results.FirstOrDefault().RoomId);
            if (result != null)
            {
                result.Occupied = "no";
                await _unitOfWork.Commit();
            }
            return result.RoomId;
        }




        public async Task Delete(int id)
        {
            var data = _roomRepository.GetById(id);
            _roomRepository.Delete(data);
            await _unitOfWork.Commit();
        }

        public async Task DeleteByRoomNo(string roomNo)
        {
            var result = _roomRepository.GetAll(x => x.RoomNo == roomNo);
            var data = _roomRepository.GetById(result.FirstOrDefault().RoomId);
            _roomRepository.Delete(data);
            await _unitOfWork.Commit();
        }

        public async Task FillterRoom()
        {
            var room = _bookingRepository.GetAll(x => x.CheckOutDate.Date == DateTime.Now.Date);
            foreach (var item in room)
            {
                var getroom = _roomRepository.GetAll(x => x.Occupied == "yes       ");
                foreach (var ittem in getroom)
                {
                    if (ittem.BookingId == item.BookingId)
                    {
                        Room roomupdate = await _roomRepository.GetSingle(ittem.RoomId);
                        roomupdate.BookingId = ittem.BookingId;
                        roomupdate.RoomNo = ittem.RoomNo;
                        roomupdate.Price = ittem.Price;
                        roomupdate.Occupied = "no";
                        roomupdate.BookingId = 0;
                        roomupdate.imagePath = ittem.imagePath;
                        await _unitOfWork.Commit();
                    }
                    await _unitOfWork.Commit();
                }
            }
            await _unitOfWork.Commit();
        }

        public async Task<Room> GetById(int id)
        {
            return await _roomRepository.GetSingle(id);
        }
        
       
        
    }
}
