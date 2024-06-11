namespace KiloPrijsCalculator.Models
{
    public class Calculation
    {
        public string Label { get; set; }
        public decimal KiloPrijs { get; set; }
        public decimal EnteredPrice { get; set; }
        public int EnteredWeight { get; set; }
    }
}
