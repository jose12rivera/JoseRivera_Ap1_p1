﻿// <auto-generated />
using System;
using JoseRivera_Ap1_p1.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace JoseRivera_Ap1_p1.Migrations
{
    [DbContext(typeof(Contexto))]
    [Migration("20241008180054_Parcial")]
    partial class Parcial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.8");

            modelBuilder.Entity("JoseRivera_Ap1_p1.Models.Deudores", b =>
                {
                    b.Property<int>("DeudorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nombres")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("PrestamoId")
                        .HasColumnType("INTEGER");

                    b.HasKey("DeudorId");

                    b.HasIndex("PrestamoId");

                    b.ToTable("Deudores");

                    b.HasData(
                        new
                        {
                            DeudorId = 1,
                            Nombres = "Jose"
                        },
                        new
                        {
                            DeudorId = 2,
                            Nombres = "Josue"
                        },
                        new
                        {
                            DeudorId = 3,
                            Nombres = "Juan"
                        });
                });

            modelBuilder.Entity("JoseRivera_Ap1_p1.Models.Prestamos", b =>
                {
                    b.Property<int>("PrestamoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<decimal?>("Balance")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Concepto")
                        .HasColumnType("TEXT");

                    b.Property<int>("DeudorId")
                        .HasColumnType("INTEGER");

                    b.Property<decimal?>("Monto")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("PrestamoId");

                    b.HasIndex("DeudorId");

                    b.ToTable("Prestamos");
                });

            modelBuilder.Entity("JoseRivera_Ap1_p1.Models.Deudores", b =>
                {
                    b.HasOne("JoseRivera_Ap1_p1.Models.Prestamos", null)
                        .WithMany("Deudor")
                        .HasForeignKey("PrestamoId");
                });

            modelBuilder.Entity("JoseRivera_Ap1_p1.Models.Prestamos", b =>
                {
                    b.HasOne("JoseRivera_Ap1_p1.Models.Deudores", "Deudores")
                        .WithMany()
                        .HasForeignKey("DeudorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Deudores");
                });

            modelBuilder.Entity("JoseRivera_Ap1_p1.Models.Prestamos", b =>
                {
                    b.Navigation("Deudor");
                });
#pragma warning restore 612, 618
        }
    }
}