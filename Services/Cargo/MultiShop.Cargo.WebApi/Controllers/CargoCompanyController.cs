using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DtoLayer.Dtos.CargoCompanyDtos;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoCompanyController : ControllerBase
    {

        private readonly ICargoCompanyService _cargoCompanyService;

        public CargoCompanyController(ICargoCompanyService cargoCompanyService)
        {
            _cargoCompanyService = cargoCompanyService;
        }

        [HttpGet]
        public IActionResult GetCargoCompanies()
        {
            var cargoCompanies = _cargoCompanyService.TGetAll();
            return Ok(cargoCompanies);
        }

        [HttpGet("{id}")]
        public IActionResult GetCargoCompany(int id)
        {
            var cargoCompany = _cargoCompanyService.TGetById(id);
            return Ok(cargoCompany);
        }

        [HttpPost]
        public IActionResult AddCargoCompany([FromBody] CreateCargoCompanyDto cargoCompanyDto)
        {
            CargoCompany cargoCompany = new CargoCompany()
            {
                Name = cargoCompanyDto.Name,
            };

            _cargoCompanyService.TAdd(cargoCompany);
            return Ok("Kargo sirketi basariyla olusturuldu");
        }

        [HttpPut]
        public IActionResult UpdateCargoCompany([FromBody] UpdateCargoCompanyDto cargoCompanyDto)
        {
            CargoCompany cargoCompany = new CargoCompany()
            {
                Id = cargoCompanyDto.Id,
                Name = cargoCompanyDto.Name,
            };

            _cargoCompanyService.TUpdate(cargoCompany);
            return Ok("Kargo sirketi basariyla guncellendi");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCargoCompany(int id)
        {
            _cargoCompanyService.TDelete(id);
            return Ok("Kargo sirketi basariyla silindi");
        }
    }
}
