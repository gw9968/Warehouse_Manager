﻿using Microsoft.EntityFrameworkCore;
using Warehouse_Manager.Models;

namespace Warehouse_Manager
{
    public class BaseConfiguration : DbContext
    {

        public BaseConfiguration(DbContextOptions<BaseConfiguration> options) : base(options)
        {

        }
        
        public DbSet<Admin> Administratorzy { get; set; }
        public DbSet<Pracownik> Pracownicy { get; set; }
        public DbSet<Produkt> Produkty { get; set; }
        public DbSet<Log> Logi { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pracownik>(entity =>
            {
                entity.HasKey(p => p.Id);
                entity.Property(p => p.Imie).HasMaxLength(50).IsRequired();
                entity.Property(p => p.Nazwisko).HasMaxLength(50).IsRequired();
                entity.Property(p => p.Login).HasMaxLength(50).IsRequired();
                entity.Property(p => p.Haslo).HasMaxLength(50).IsRequired();
                entity.Property(p => p.DataZatrudnienia).IsRequired();

                entity.HasMany(p => p.Logi)
                      .WithOne(l => l.Pracownik)
                      .HasForeignKey(l => l.PracownikId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Produkt>(entity =>
            {
                entity.HasKey(p => p.Id);
                entity.Property(p => p.Nazwa).HasMaxLength(100).IsRequired();
                entity.Property(p => p.Cena).HasColumnType("decimal(10,2)").IsRequired();
                entity.Property(p => p.Ilosc).IsRequired();

                entity.HasMany(p => p.Logi)
                      .WithOne(l => l.Produkt)
                      .HasForeignKey(l => l.ProduktId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Log>(entity =>
            {
                entity.HasKey(l => l.Id);
                entity.Property(l => l.Akcja).HasMaxLength(20).IsRequired();
                entity.Property(l => l.CzasAkcji).IsRequired();

                entity.HasOne(l => l.Pracownik)
                      .WithMany(p => p.Logi)
                      .HasForeignKey(l => l.PracownikId);

                entity.HasOne(l => l.Produkt)
                      .WithMany(p => p.Logi)
                      .HasForeignKey(l => l.ProduktId)
                      .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
