using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SpeedSolutionsChallenge.Data.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        [Required]
        [MaxLength(50)]
        public string ProductType { get; set; }

        [Required]
        [MaxLength(50)]
        public string Unit { get; set; }

        public bool IsDeleted { get; set; }

        public List<Price>? Prices { get; set; }
        public List<Hose>? Hoses { get; set; }
    }

}
