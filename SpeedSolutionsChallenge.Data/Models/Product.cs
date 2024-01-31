using System.ComponentModel.DataAnnotations;

namespace SpeedSolutionsChallenge.Data.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public ProductType Type { get; set; }

        [Required]
        public UnitType Unit { get; set; }

        public bool IsDeleted { get; set; }

        public List<Price> Prices { get; set; }

        public Dispenser Dispenser { get; set; }

        public List<Hose> Hoses { get; set; }
    }

    public enum ProductType
    {
        Combustible,
        Lubricante
    }

    public enum UnitType
    {
        Galones,
        Litros
    }
}
