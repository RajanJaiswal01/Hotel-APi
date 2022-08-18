using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
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
        [Route("UpdateRoom")]
        public async Task<Int64> Update(string roomNo)
        {
            if (roomNo == "") return 0;
            var result = await _roomService.UpdateRoom(roomNo);
            return result;
        }



        [HttpPost]
        [Route("delete")]

        public async Task Delete(int id)
        {
            await _roomService.Delete(id);
        }

        [HttpPost]
        [Route("deleteByRoomNo")]
        public async Task deleteroomByRoomNo(string roomNo)
        {
            await _roomService.DeleteByRoomNo(roomNo);  
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


        [HttpPost,Route("Upload"), DisableRequestSizeLimit]
        public IActionResult Upload()
        {
            try
            {
                var file = Request.Form.Files[0];
                var folderName = Path.Combine("Resources", "Images");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                if (file.Length > 0)
                {
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    var fullPath = Path.Combine(pathToSave, fileName);
                    var dbPath = Path.Combine(folderName, fileName);
                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                    return Ok(new { dbPath });
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }
    }
}
