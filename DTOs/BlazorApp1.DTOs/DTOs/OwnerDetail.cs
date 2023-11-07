using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BlazorApp1.DTOs.DTOs
{
    public class OwnerDetail
    {
        public Guid OwnerId { get; set; }

        [Required]
        [Column("OwnerFName")]
        [StringLength(100)]
        [Unicode(false)]
        public string OwnerFname { get; set; } = null!;

        [Required]
        [Column("OwnerLName")]
        [StringLength(100)]
        [Unicode(false)]
        public string OwnerLname { get; set; } = null!;
    }
}
