using System;
using System.Collections.Generic;
using BlazorApp1.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp1.DataAccess;

public partial class PracticeDBContext : DbContext
{
    public PracticeDBContext()
    {
    }

    public PracticeDBContext(DbContextOptions<PracticeDBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Car> Cars { get; set; }

    public virtual DbSet<CarOwner> CarOwners { get; set; }

    public virtual DbSet<Owner> Owners { get; set; }

    
    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //    => optionsBuilder.UseSqlServer("name=PracticeDBContext");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Car>(entity =>
        {
            entity.HasKey(e => e.CarId).HasName("PK__Cars__68A0342E87A27866");

            entity.Property(e => e.CarId).HasDefaultValueSql("(newid())");
        });

        modelBuilder.Entity<CarOwner>(entity =>
        {
            entity.HasKey(e => e.CarOwnerId).HasName("PK__CarOwner__335FB21C9D1CBE20");

            entity.Property(e => e.CarOwnerId).HasDefaultValueSql("(newid())");

            entity.HasOne(d => d.AnOwnerNavigation).WithMany(p => p.CarOwners).HasConstraintName("FK__CarOwners__AnOwn__4F7CD00D");

            entity.HasOne(d => d.CarNavigation).WithMany(p => p.CarOwners).HasConstraintName("FK__CarOwners__Car__4E88ABD4");
        });

        modelBuilder.Entity<Owner>(entity =>
        {
            entity.HasKey(e => e.OwnerId).HasName("PK__Owners__819385B8F43DF52F");

            entity.Property(e => e.OwnerId).HasDefaultValueSql("(newid())");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
