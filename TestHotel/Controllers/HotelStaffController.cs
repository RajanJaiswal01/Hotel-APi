using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestHotel.DTOs;
using TestHotel.Entities;
using TestHotel.Service;
using TestHotel.Service.IService;

namespace TestHotel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelStaffController : ControllerBase
    {
        private readonly IHotelStaffService _hotelStaffService;

        public HotelStaffController(IHotelStaffService hotelStaffService)
        {
            _hotelStaffService = hotelStaffService;
        }

        [HttpGet]
        [Route("GetAll")]
        public ActionResult<HotelStaff> GetAll()
        {
            var result = _hotelStaffService.GetAll();
            return Ok(result);
        }
        [HttpPost]
        [Route("Create")]
        public async Task<Int64> Create(HotelStaffDTO model)
        {
            if (model == null) return 0;
            var result = await _hotelStaffService.Create(model);
            return result;
        }

        [HttpPost]
        [Route("Update")]
        public async Task<Int64> Update(HotelStaffDTO model)
        {
            if (model == null) return 0;
            var result = await _hotelStaffService.Update(model);
            return result;
        }

        [HttpPost]
        [Route("delete")]

        public async Task Delete(int id)
        {
            await _hotelStaffService.Delete(id);
        }


        [HttpGet]
        [Route("GetById")]
        public async Task<HotelStaff> GetById(int id)
        {
            var result = await _hotelStaffService.GetById(id);
            return result;
        }
    }
}
