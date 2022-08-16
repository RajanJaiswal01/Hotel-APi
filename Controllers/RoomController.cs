using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestHotel.DTOs;
using TestHotel.Entities;
using TestHotel.Service.IService;

namespace TestHotel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IRoomService _roomService;

        public RoomController(IRoomService RoomService)
        {
            _roomService = RoomService;
        }

        [HttpGet]
        [Route("GetAll")]
        public ActionResult<Room> GetAll()
        {
            var result = _roomService.GetAll();
            return Ok(result);
        }

        [HttpPost]
        [Route("Create")]
        public async Task<Int64> Create(RoomDTO model)
        {
            if (model == null) return 0;
            var result = await _roomService.Create(model);
            return result;
        }

        [HttpGet]
        [Route("filterRoom")]
        public  async  void FilterRoom()
        {
            _roomService.FillterRoom();
        }

        [HttpPost]
        [Route("Update")]
        public async Task<Int64> Update(RoomDTO model)
        {
            if (model == null) return 0;
            var result = await _roomService.Update(model);
            return result;
        }

        [HttpPost]
        [Route("delete")]

        public async Task Delete(int id)
        {
            await _roomService.Delete(id);
        }


        [HttpPost]
        [Route("GetById")]
        public async Task<Room> GetById(int id)
        {
            var result = await _roomService.GetById(id);
            return result;
        }

        [HttpGet]
        [Route("getbyROomType")]

        public List<Room> GetRoomByType(string type)
        {
            List<Room> result = _roomService.GetRoomByType(type);
            return result;
        }
    }
}
