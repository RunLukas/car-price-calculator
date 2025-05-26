namespace CarPriceApi.Models
{
    public class CarPriceResponse
    {
        public decimal CarPriceNet { get; set; }
        public decimal CarPriceGross { get; set; }

        public decimal EquipmentPriceNet { get; set; }
        public decimal EquipmentPriceGross { get; set; }
        public decimal TotalNet { get; set; }
        public decimal TotalGross { get; set; }
    }
}
