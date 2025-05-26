namespace CarPriceApi.Models
{
    public class CarPriceRequest
    {
        public decimal Vat { get; set; }

        public decimal? CarPriceNet { get; set; }
        public decimal? CarPriceGross { get; set; }

        public decimal? EquipmentPriceNet { get; set; }
        public decimal? EquipmentPriceGross { get; set; }
    }
}
