using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WirlessMediaSimpleCRUD.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(64, ErrorMessage = "Name length can't be more than 64.")]
        public string Name { get; set; }

        [Required]
        [StringLength(256, ErrorMessage = "Description length can't be more than 256.")]
        public string Description { get; set; }

        [Required]
        [StringLength(36, ErrorMessage = "Category length can't be more than 36.")]
        public string Category { get; set; }

        [Required]
        [StringLength(36, ErrorMessage = "Manufacturer length can't be more than 36.")]
        public string Manufacturer { get; set; }

        [Required]
        [StringLength(36, ErrorMessage = "Supplier length can't be more than 36.")]
        public string Supplier { get; set; }

        [Required]
        [Range(0, 99999.99, ErrorMessage = "Cost have to be between (0 and 99999.99).")]
        public double Cost { get; set; }

    }
}
