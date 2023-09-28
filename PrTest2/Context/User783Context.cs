using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PrTest2.Models;

namespace PrTest2.Context;

public partial class User783Context : DbContext
{
    public User783Context()
    {
    }

    public User783Context(DbContextOptions<User783Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Nation> Nations { get; set; }

    public virtual DbSet<Sportsman> Sportsmans { get; set; }

    public virtual DbSet<TypesOfSport> TypesOfSports { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql("Database=user783; Host=192.168.0.4; Password=49242; Username=user783;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Nation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("nation_pkey");

            entity.ToTable("nation", "Test");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Title)
                .HasMaxLength(100)
                .HasColumnName("title");
        });

        modelBuilder.Entity<Sportsman>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("sportsmans_pkey");

            entity.ToTable("sportsmans", "Test");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Age).HasColumnName("age");
            entity.Property(e => e.Height).HasColumnName("height");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.Nationality).HasColumnName("nationality");
            entity.Property(e => e.Patronymic)
                .HasMaxLength(100)
                .HasColumnName("patronymic");
            entity.Property(e => e.Sport).HasColumnName("sport");
            entity.Property(e => e.Surname)
                .HasMaxLength(100)
                .HasColumnName("surname");
            entity.Property(e => e.Weight).HasColumnName("weight");

            entity.HasOne(d => d.NationalityNavigation).WithMany(p => p.Sportsmen)
                .HasForeignKey(d => d.Nationality)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("sportsmans_nationality_fkey");

            entity.HasOne(d => d.SportNavigation).WithMany(p => p.Sportsmen)
                .HasForeignKey(d => d.Sport)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("sportsmans_sport_fkey");
        });

        modelBuilder.Entity<TypesOfSport>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("types_of_sports_pkey");

            entity.ToTable("types_of_sports", "Test");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Title)
                .HasMaxLength(100)
                .HasColumnName("title");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
