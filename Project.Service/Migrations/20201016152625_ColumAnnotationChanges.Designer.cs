﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Project.Service.Models;

namespace Project.Service.DataAccess.Migrations
{
    [DbContext(typeof(VehicleDbContext))]
    [Migration("20201016152625_ColumAnnotationChanges")]
    partial class ColumAnnotationChanges
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Project.Service.Models.VehicleMake", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Abrv")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("vehicle_make");

                    b.HasData(
                        new
                        {
                            Id = 325,
                            Abrv = "BMW",
                            Name = "BMW"
                        },
                        new
                        {
                            Id = 100,
                            Abrv = "Ford",
                            Name = "Ford"
                        },
                        new
                        {
                            Id = 200,
                            Abrv = "VW",
                            Name = "Volkswagen"
                        });
                });

            modelBuilder.Entity("Project.Service.Models.VehicleModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Abrv")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("MakeId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.HasIndex("MakeId");

                    b.ToTable("vehicle_model");

                    b.HasData(
                        new
                        {
                            Id = 128,
                            Abrv = "X5",
                            MakeId = 325,
                            Name = "X5 (BMW)"
                        },
                        new
                        {
                            Id = 2,
                            Abrv = "Golf 6",
                            MakeId = 200,
                            Name = "Golf 6 (VW) "
                        },
                        new
                        {
                            Id = 3,
                            Abrv = "Golf 7",
                            MakeId = 200,
                            Name = "Golf 7 (VW)"
                        });
                });

            modelBuilder.Entity("Project.Service.Models.VehicleModel", b =>
                {
                    b.HasOne("Project.Service.Models.VehicleMake", null)
                        .WithMany()
                        .HasForeignKey("MakeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
