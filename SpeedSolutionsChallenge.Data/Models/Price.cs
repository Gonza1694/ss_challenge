using System.ComponentModel.DataAnnotations;

namespace SpeedSolutionsChallenge.Data.Models
{
    public class Price
    {
        [Key]
        public int PriceId { get; set; }

        [Required]
        public decimal Value { get; set; }

        [Required]
        public DateTime Date { get; set; }

        public int ProductId { get; set; }

        public Product Product { get; set; }
    }
}
