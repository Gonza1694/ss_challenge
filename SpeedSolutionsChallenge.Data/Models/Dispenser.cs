using Microsoft.Extensions.Hosting;
using System.ComponentModel.DataAnnotations;

namespace SpeedSolutionsChallenge.Data.Models
{
    public class Dispenser
    {
        [Key]
        public int DispenserId { get; set; }

        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        [Required]
        public int HoseCount { get; set; }

        public List<Hose>? Hoses { get; set; }
    }
}
