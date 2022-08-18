using Microsoft.AspNetCore.Mvc;
using TestHotel.DTOs;
using TestHotel.Entities;
using TestHotel.Service.IService;

namespace TestHotel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;

        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpGet]
        [Route("GetAll")]
        public ActionResult<Booking> GetAll()
        {
            var result = _bookingService.GetAll();
            return Ok(result);
        }

        [HttpPost]
        [Route("Create")]
        public async Task<Int64> Create([FromBody] BookingDTO model)
        {
            if (model == null) return 0;
            var result = await _bookingService.Create(model);
            return result;
        }


        [HttpPost]
        [Route("Update")]
        public async Task<Int64> Update(BookingDTO model)
        {
            if (model == null) return 0;
            var result = await _bookingService.Update(model);
            return result;
        }

        [HttpPost]
        [Route("Delete")]

        public async Task Delete(int id)
        {
            await _bookingService.Delete(id);
        }


        [HttpGet]
        [Route("GetById")]
        public async Task<Booking> GetById(int id)
        {
            var result = await _bookingService.GetById(id);
            return result;
        }
    }

}
