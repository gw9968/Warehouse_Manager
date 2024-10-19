﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Warehouse_Manager.Models;

#nullable disable

namespace Warehouse_Manager.Migrations
{
    [DbContext(typeof(BaseConfiguration))]
    [Migration("20241019203032_tabele-w1")]
    partial class tabelew1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Warehouse_Manager.Models.Log", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Akcja")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<DateTime>("CzasAkcji")
                        .HasColumnType("datetime2");

                    b.Property<int>("PracownikId")
                        .HasColumnType("int");

                    b.Property<int>("ProduktId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PracownikId");

                    b.HasIndex("ProduktId");

                    b.ToTable("Logi");
                });

            modelBuilder.Entity("Warehouse_Manager.Models.Pracownik", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DataZatrudnienia")
                        .HasColumnType("datetime2");

                    b.Property<string>("Haslo")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Imie")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Nazwisko")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("Zalogowany")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Pracownicy");
                });

            modelBuilder.Entity("Warehouse_Manager.Models.Produkt", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Cena")
                        .HasColumnType("decimal(10,2)");

                    b.Property<int>("Ilosc")
                        .HasColumnType("int");

                    b.Property<string>("Kategoria")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nazwa")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Produkty");
                });

            modelBuilder.Entity("Warehouse_Manager.Models.Log", b =>
                {
                    b.HasOne("Warehouse_Manager.Models.Pracownik", "Pracownik")
                        .WithMany("Logi")
                        .HasForeignKey("PracownikId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Warehouse_Manager.Models.Produkt", "Produkt")
                        .WithMany("Logi")
                        .HasForeignKey("ProduktId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pracownik");

                    b.Navigation("Produkt");
                });

            modelBuilder.Entity("Warehouse_Manager.Models.Pracownik", b =>
                {
                    b.Navigation("Logi");
                });

            modelBuilder.Entity("Warehouse_Manager.Models.Produkt", b =>
                {
                    b.Navigation("Logi");
                });
#pragma warning restore 612, 618
        }
    }
}
