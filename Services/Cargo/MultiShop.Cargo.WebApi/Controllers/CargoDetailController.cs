using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DtoLayer.Dtos.CargoDetailDtos;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoDetailController : ControllerBase
    {

        private readonly ICargoDetailService _cargoDetailService;


        public CargoDetailController(ICargoDetailService cargoDetailService)
        {
            _cargoDetailService = cargoDetailService;
        }

        [HttpGet]
        public IActionResult GetCargoDetails()
        {
            var cargoDetails = _cargoDetailService.TGetAll();
            return Ok(cargoDetails);
        }

        [HttpGet("{id}")]
        public IActionResult GetCargoDetail(int id)
        {
            var cargoDetail = _cargoDetailService.TGetById(id);
            return Ok(cargoDetail);
        }

        [HttpPost]
        public IActionResult AddCargoDetail([FromBody] CreateCargoDetailDto cargoDetailDto)
        {
            CargoDetail cargoDetail = new CargoDetail()
            {
                CargoCompanyId = cargoDetailDto.CargoCompanyId,
                Barcode = cargoDetailDto.Barcode,
                SenderCustomer  = cargoDetailDto.SenderCustomer,
                ReceiverCustomer = cargoDetailDto.ReceiverCustomer,
            };

            _cargoDetailService.TAdd(cargoDetail);
            return Ok("Kargo detayi basariyla olusturuldu");
        }

        [HttpPut]
        public IActionResult UpdateCargoDetail([FromBody] UpdateCargoDetailDto cargoDetailDto)
        {
            CargoDetail cargoDetail = new CargoDetail()
            {
                Id = cargoDetailDto.Id,
                CargoCompanyId = cargoDetailDto.CargoCompanyId,
                Barcode = cargoDetailDto.Barcode,
                SenderCustomer = cargoDetailDto.SenderCustomer,
                ReceiverCustomer = cargoDetailDto.ReceiverCustomer,
            };

            _cargoDetailService.TUpdate(cargoDetail);
            return Ok("Kargo detayi basariyla guncellendi");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCargoDetail(int id)
        {
            _cargoDetailService.TDelete(id);
            return Ok("Kargo detayi basariyla silindi");
        }

        


    }
}
