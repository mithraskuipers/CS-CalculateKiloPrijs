using System.ComponentModel.DataAnnotations;

namespace KiloPrijsCalculator.Models
{
    public class Product
    {
        [Required]
        [Display(Name = "Price (in Euros)")]
        public decimal Price { get; set; }

        [Required]
        [Display(Name = "Weight (in Grams)")]
        public int Weight { get; set; }

        [Display(Name = "Label")]
        public string Label { get; set; }

        [Display(Name = "Discount (%)")]
        public int Discount { get; set; } = 0;

        public decimal AdjustedPrice => Price * ((100 - Discount) / 100m);

        public decimal KiloPrijs => (Weight > 0) ? (AdjustedPrice / (Weight / 1000m)) : 0;
    }
}
