
namespace POSTerminal.Models
{
    internal class ProductPricing
    {
        public string ProductCode { get; set; }
        public decimal UnitPrice { get; set; }
        public bool HasVolumePrice { get; set; }
        public decimal VolumePrice { get; set; }
        public int Volume { get; set; }
    }
}
