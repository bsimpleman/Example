using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace BlazorApp1.DTOs.DTOs
{
    public class CarDetails
    {
        public Guid CarId { get; set; }

        [Required]
        [StringLength(100)]
        [Unicode(false)]
        public string Make { get; set; } = null!;

        [Required]
        [StringLength(100)]
        [Unicode(false)]
        public string Model { get; set; } = null!;

        [Required]
        public int CarYear { get; set; }

        //[Required]
        //[Column(TypeName = "decimal(18, 2)")]
        //public decimal Price { get; set; }

        //[StringLength(5000)]
        //[Unicode(false)]
        //public string? CarDesc { get; set; }
    }
}
