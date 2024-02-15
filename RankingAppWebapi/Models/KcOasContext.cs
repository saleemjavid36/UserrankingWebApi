using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace RankingAppWebapi.Models;

public partial class KcOasContext : DbContext
{
    public KcOasContext()
    {
    }

    public KcOasContext(DbContextOptions<KcOasContext> options)
        : base(options)
    {
    }

    public virtual DbSet<SampleUserRanking> SampleUserRankings { get; set; }

    public virtual DbSet<UserRanking> UserRankings { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {

        }
    }
        

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<SampleUserRanking>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__sampleUs__3214EC278935AF13");

            entity.ToTable("sampleUserRankings");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Name).IsUnicode(false);
        });

        modelBuilder.Entity<UserRanking>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__userRank__3214EC2709523E46");

            entity.ToTable("userRankings");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Name).IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
