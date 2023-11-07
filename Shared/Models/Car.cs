using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp1.Data.Models;

public partial class Car
{
    [StringLength(100)]
    [Unicode(false)]
    public string Make { get; set; } = null!;

    [StringLength(100)]
    [Unicode(false)]
    public string Model { get; set; } = null!;

    public int CarYear { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal Price { get; set; }

    [StringLength(5000)]
    [Unicode(false)]
    public string? CarDesc { get; set; }

    [Key]
    public Guid CarId { get; set; }

    [InverseProperty("CarNavigation")]
    public virtual ICollection<CarOwner> CarOwners { get; set; } = new List<CarOwner>();
}
