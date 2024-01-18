using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace StichtingAccessibility.Server.Models;

public partial class StichtingDbContext : IdentityDbContext
{
    public StichtingDbContext()
    {
    }

    public StichtingDbContext(DbContextOptions<StichtingDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Customer> Customers { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Customer__A4AE64D8BBE16905");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.LastName).HasMaxLength(50);
        });
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
