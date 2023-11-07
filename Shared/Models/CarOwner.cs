using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp1.Data.Models;

public partial class CarOwner
{
    [Key]
    public Guid CarOwnerId { get; set; }

    public Guid? Car { get; set; }

    public Guid? AnOwner { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime OwnStart { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? OwnEnd { get; set; }

    [ForeignKey("AnOwner")]
    [InverseProperty("CarOwners")]
    public virtual Owner? AnOwnerNavigation { get; set; }

    [ForeignKey("Car")]
    [InverseProperty("CarOwners")]
    public virtual Car? CarNavigation { get; set; }
}
