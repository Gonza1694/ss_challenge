using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SpeedSolutionsChallenge.Data.Models
{
    public class Hose
    {
        [Key]
        public int HoseId { get; set; }

        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        public int? DispenserId { get; set; }

        public int? ProductId { get; set; } 

        public bool IsDeleted { get; set; }

    }

}
