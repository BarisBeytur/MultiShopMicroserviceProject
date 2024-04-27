using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DtoLayer.Dtos.CargoCustomerDtos;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoCustomerController : ControllerBase
    {

        private readonly ICargoCustomerService _cargoCustomerService;


        public CargoCustomerController(ICargoCustomerService cargoCustomerService)
        {
            _cargoCustomerService = cargoCustomerService;
        }

        [HttpGet]
        public IActionResult GetCargoCustomers()
        {
            var cargoCustomers = _cargoCustomerService.TGetAll();
            return Ok(cargoCustomers);
        }

        [HttpGet("{id}")]
        public IActionResult GetCargoCustomer(int id)
        {
            var cargoCustomer = _cargoCustomerService.TGetById(id);
            return Ok(cargoCustomer);
        }

        [HttpPost]
        public IActionResult AddCargoCustomer([FromBody] CreateCargoCustomerDto cargoCustomerDto)
        {
            CargoCustomer cargoCustomer = new CargoCustomer()
            {
                Name = cargoCustomerDto.Name,
                Address = cargoCustomerDto.Address,
                Phone = cargoCustomerDto.Phone,
                Email = cargoCustomerDto.Email,
            };

            _cargoCustomerService.TAdd(cargoCustomer);
            return Ok("Kargo musteri basariyla olusturuldu");
        }

        [HttpPut]
        public IActionResult UpdateCargoCustomer([FromBody] UpdateCargoCustomerDto cargoCustomerDto)
        {
            CargoCustomer cargoCustomer = new CargoCustomer()
            {
                Id = cargoCustomerDto.Id,
                Name = cargoCustomerDto.Name,
                Address = cargoCustomerDto.Address,
                Phone = cargoCustomerDto.Phone,
                Email = cargoCustomerDto.Email,
            };

            _cargoCustomerService.TUpdate(cargoCustomer);
            return Ok("Kargo musteri basariyla guncellendi");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCargoCustomer(int id)
        {
            _cargoCustomerService.TDelete(id);
            return Ok("Kargo musteri basariyla silindi");
        }
    }
}
