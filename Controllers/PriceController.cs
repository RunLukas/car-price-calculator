using Microsoft.AspNetCore.Mvc;
using CarPriceApi.Models;
using CarPriceApi.Helpers;

namespace CarPriceApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarPriceController : ControllerBase
    {
        [HttpPost("calculate")]
        public ActionResult<CarPriceResponse> Calculate([FromBody] CarPriceRequest request)
        {
            if (request.Vat < 0 || request.Vat > 1)
                return BadRequest("VAT must be between 0 and 1 (e.g., 0.22 for 22%)");

            decimal carNet = VatCalculator.ToNet(request.CarPriceNet, request.CarPriceGross, request.Vat);
            decimal carGross = VatCalculator.ToGross(request.CarPriceGross, request.CarPriceNet, request.Vat);

            decimal eqNet = VatCalculator.ToNet(request.EquipmentPriceNet, request.EquipmentPriceGross, request.Vat);
            decimal eqGross = VatCalculator.ToGross(request.EquipmentPriceGross, request.EquipmentPriceNet, request.Vat);

            decimal totalNet = carNet + eqNet;
            decimal totalGross = carGross + eqGross;

            return Ok(new CarPriceResponse
            {
                CarPriceNet = Math.Round(carNet, 2),
                CarPriceGross = Math.Round(carGross, 2),
                EquipmentPriceNet = Math.Round(eqNet, 2),
                EquipmentPriceGross = Math.Round(eqGross, 2),
                TotalNet = Math.Round(totalNet, 2),
                TotalGross = Math.Round(totalGross, 2)
            });
        }
    }
}
