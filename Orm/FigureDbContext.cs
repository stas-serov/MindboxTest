using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Orm.SQLServer.Models;

namespace Orm.SQLServer;

public partial class FigureDbContext : DbContext
{
    public FigureDbContext()
    {
    }

    public FigureDbContext(DbContextOptions<FigureDbContext> options)
        : base(options)
    {
        Database.EnsureCreated();
    }

    public virtual DbSet<Figure> Figures { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Figure>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Figure__3214EC07B7514807");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
