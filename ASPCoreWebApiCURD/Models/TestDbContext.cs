using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ASPCoreWebApiCURD.Models;

public partial class TestDbContext : DbContext
{
    public TestDbContext()
    {
    }

    public TestDbContext(DbContextOptions<TestDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Student> Students { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
      {
        if (!optionsBuilder.IsConfigured)
        {
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Table__3214EC075E7B87E8");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.FatherName).IsFixedLength();
            entity.Property(e => e.StudentGender).IsFixedLength();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
