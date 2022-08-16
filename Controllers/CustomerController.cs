using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestHotel.Entities;
using TestHotel.DTOs;
using TestHotel.Service.IService;

namespace TestHotel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        [Route("GetAll")]
        public ActionResult<Customer> GetAll()
        {
            var result = _customerService.GetAll();
            return Ok(result);
        }

        [HttpGet]
        [Route("filterUser")]
        public IActionResult FilterUser()
        {
            _customerService.FilterUser();
            return Ok();
        }

        [HttpPost]
        [Route("Create")]
        public async Task<Int64> Create(CustomerDTO model)
        {
            if (model == null) return 0;
            var result = await _customerService.Create(model);
            return result;
        }

        [HttpPost]
        [Route("Update")]
        public async Task<Int64> Update(CustomerDTO model)
        {
            if (model == null) return 0;
            var result = await _customerService.Update(model);
            return result;
        }

        [HttpPost]
        [Route("delete")]

        public async Task Delete(int id)
        {
            await _customerService.Delete(id);
        }


        [HttpPost]
        [Route("GetById")]
        public async Task<Customer> GetById(int id)
        {
            var result = await _customerService.GetById(id);
            return result;
        }
    }
}
