namespace Triquetra.Domain.Data.Entities
{
    public class Offer : BaseEntity
    {
        public double SetupArea { get; set; }
        public int InverterCount { get; set; }
        public int PanelCount { get; set; }
        public double TotalPriceTL { get; set; }
        public double TotalPriceDollar { get; set; }
        public double? DiscountRate { get; set; }
        public double? DiscountedPriceTL { get; set; }
    }
}