namespace Triquetra.Domain.DTO.Offers
{
    public class CreateOfferDTO
    {
        public int Id { get; set; }
        public double SetupArea { get; set; }
        public int InverterCount { get; set; }
        public int PanelCount { get; set; }
        public float TotalPriceTL { get; set; }
        public float TotalPriceDollar { get; set; }
        public double? DiscountRate { get; set; }
        public double? DiscountedPriceTL { get; set; }
    }
}