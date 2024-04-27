using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DtoLayer.Dtos.CargoOperationDtos;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoOperationController : ControllerBase
    {

        private readonly ICargoOperationService _cargoOperationService;

        public CargoOperationController(ICargoOperationService cargoOperationService)
        {
            _cargoOperationService = cargoOperationService;
        }

        [HttpGet]
        public IActionResult GetCargoOperations()
        {
            var cargoOperations = _cargoOperationService.TGetAll();
            return Ok(cargoOperations);
        }

        [HttpGet("{id}")]
        public IActionResult GetcargoOperation(int id)
        {
            var cargoOperation = _cargoOperationService.TGetById(id);
            return Ok(cargoOperation);
        }

        [HttpPost]
        public IActionResult AddcargoOperation([FromBody] CreateCargoOperationDto cargoOperationDto)
        {
            CargoOperation cargoOperation = new CargoOperation()
            {
                OperationDate = cargoOperationDto.OperationDate,
                Barcode = cargoOperationDto.Barcode,
                Description = cargoOperationDto.Description
            };

            _cargoOperationService.TAdd(cargoOperation);
            return Ok("Kargo operasyonu basariyla olusturuldu");
        }

        [HttpPut]
        public IActionResult UpdatecargoOperation([FromBody] UpdateCargoOperationDto cargoOperationDto)
        {
            CargoOperation cargoOperation = new CargoOperation()
            {
                OperationDate = cargoOperationDto.OperationDate,
                Barcode = cargoOperationDto.Barcode,
                Description = cargoOperationDto.Description,
                Id = cargoOperationDto.Id
            };

            _cargoOperationService.TUpdate(cargoOperation);
            return Ok("Kargo operasyonu basariyla guncellendi");
        }

        [HttpDelete("{id}")]
        public IActionResult DeletecargoOperation(int id)
        {
            _cargoOperationService.TDelete(id);
            return Ok("Kargo operasyonu basariyla silindi");
        }


    }
}
