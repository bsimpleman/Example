using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp1.Data.Models;

public partial class Owner
{
    [Column("OwnerFName")]
    [StringLength(100)]
    [Unicode(false)]
    public string OwnerFname { get; set; } = null!;

    [Column("OwnerLName")]
    [StringLength(100)]
    [Unicode(false)]
    public string OwnerLname { get; set; } = null!;

    [Key]
    public Guid OwnerId { get; set; }

    [InverseProperty("AnOwnerNavigation")]
    public virtual ICollection<CarOwner> CarOwners { get; set; } = new List<CarOwner>();
}
