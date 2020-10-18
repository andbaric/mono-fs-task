﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Project.Service.Models;

namespace Project.Service.DataAccess.Migrations
{
    [DbContext(typeof(VehicleDbContext))]
    partial class VehicleDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
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
                            Id = 1,
                            Abrv = "BMW",
                            Name = "Bayerische Motoren Werke"
                        },
                        new
                        {
                            Id = 2,
                            Abrv = "VW",
                            Name = "Volkswagen"
                        },
                        new
                        {
                            Id = 3,
                            Abrv = "Opel",
                            Name = "Opel"
                        },
                        new
                        {
                            Id = 4,
                            Abrv = "Audi",
                            Name = "Audi"
                        },
                        new
                        {
                            Id = 5,
                            Abrv = "Renault",
                            Name = "Renault"
                        },
                        new
                        {
                            Id = 6,
                            Abrv = "Ford",
                            Name = "Ford"
                        },
                        new
                        {
                            Id = 7,
                            Abrv = "Peugeot",
                            Name = "Peugeot"
                        },
                        new
                        {
                            Id = 8,
                            Abrv = "Mazda",
                            Name = "Mazda"
                        },
                        new
                        {
                            Id = 9,
                            Abrv = "Toyota",
                            Name = "Toyota"
                        },
                        new
                        {
                            Id = 10,
                            Abrv = "Honda",
                            Name = "Honda"
                        },
                        new
                        {
                            Id = 11,
                            Abrv = "Suzuki",
                            Name = "Suzuki"
                        },
                        new
                        {
                            Id = 12,
                            Abrv = "Mitsubishi",
                            Name = "Mitsubishi"
                        },
                        new
                        {
                            Id = 13,
                            Abrv = "Mercedes",
                            Name = "Mercedes-Benz"
                        },
                        new
                        {
                            Id = 14,
                            Abrv = "Kia",
                            Name = "Kia"
                        },
                        new
                        {
                            Id = 15,
                            Abrv = "Hyundai",
                            Name = "Hyundai"
                        },
                        new
                        {
                            Id = 16,
                            Abrv = "Nissan",
                            Name = "Nissan"
                        },
                        new
                        {
                            Id = 17,
                            Abrv = "Rimac",
                            Name = "Rimac"
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
                            Id = 1,
                            Abrv = "X5",
                            MakeId = 1,
                            Name = "X5 (BMW)"
                        },
                        new
                        {
                            Id = 2,
                            Abrv = "M4",
                            MakeId = 1,
                            Name = "M4 (BMW)"
                        },
                        new
                        {
                            Id = 3,
                            Abrv = "Golf 7",
                            MakeId = 2,
                            Name = "Golf 7 (VW)"
                        },
                        new
                        {
                            Id = 4,
                            Abrv = "Pasat",
                            MakeId = 2,
                            Name = "Pasat (VW)"
                        },
                        new
                        {
                            Id = 5,
                            Abrv = "Arteon",
                            MakeId = 2,
                            Name = "Arteon (VW) "
                        },
                        new
                        {
                            Id = 6,
                            Abrv = "Corsa",
                            MakeId = 3,
                            Name = "Corsa (Opel)"
                        },
                        new
                        {
                            Id = 7,
                            Abrv = "A4",
                            MakeId = 4,
                            Name = "A4 (Audi)"
                        },
                        new
                        {
                            Id = 8,
                            Abrv = "Q5",
                            MakeId = 4,
                            Name = "Q5 (Audi) "
                        },
                        new
                        {
                            Id = 9,
                            Abrv = "Q7",
                            MakeId = 4,
                            Name = "Q7 (Audi)"
                        },
                        new
                        {
                            Id = 10,
                            Abrv = "Megane",
                            MakeId = 5,
                            Name = "Megane (Renault)"
                        },
                        new
                        {
                            Id = 11,
                            Abrv = "Renault",
                            MakeId = 5,
                            Name = "Clio (Renault) "
                        },
                        new
                        {
                            Id = 12,
                            Abrv = "Mondeo",
                            MakeId = 6,
                            Name = "Mondeo (Ford)"
                        },
                        new
                        {
                            Id = 13,
                            Abrv = "Mustang",
                            MakeId = 6,
                            Name = "Mustang (Ford)"
                        },
                        new
                        {
                            Id = 14,
                            Abrv = "Fiesta",
                            MakeId = 6,
                            Name = "Fiesta (Ford) "
                        },
                        new
                        {
                            Id = 15,
                            Abrv = "Focus",
                            MakeId = 6,
                            Name = "Focus (Ford)"
                        },
                        new
                        {
                            Id = 16,
                            Abrv = "206",
                            MakeId = 7,
                            Name = "206 (Peugeot)"
                        },
                        new
                        {
                            Id = 17,
                            Abrv = "6",
                            MakeId = 8,
                            Name = "6 (Mazda)"
                        },
                        new
                        {
                            Id = 18,
                            Abrv = "3",
                            MakeId = 8,
                            Name = "3 (Mazda)"
                        },
                        new
                        {
                            Id = 19,
                            Abrv = "RAV4",
                            MakeId = 9,
                            Name = "RAV4 (Toyota)"
                        },
                        new
                        {
                            Id = 20,
                            Abrv = "Corola",
                            MakeId = 9,
                            Name = "Corola (Toyota) "
                        },
                        new
                        {
                            Id = 21,
                            Abrv = "Yaris",
                            MakeId = 9,
                            Name = "Yaris (Toyota)"
                        },
                        new
                        {
                            Id = 22,
                            Abrv = "Auris",
                            MakeId = 9,
                            Name = "Auris (Toyota)"
                        },
                        new
                        {
                            Id = 23,
                            Abrv = "CR-V",
                            MakeId = 10,
                            Name = "CR-V (Honda)"
                        },
                        new
                        {
                            Id = 24,
                            Abrv = "Accord",
                            MakeId = 10,
                            Name = "Accord (Honda)"
                        },
                        new
                        {
                            Id = 25,
                            Abrv = "SWIFT",
                            MakeId = 11,
                            Name = "Swift (Suzuki)"
                        },
                        new
                        {
                            Id = 26,
                            Abrv = "Ignis",
                            MakeId = 11,
                            Name = "Ignis (Suzuki) "
                        },
                        new
                        {
                            Id = 27,
                            Abrv = "Jimny",
                            MakeId = 11,
                            Name = "Jimny 7 (Suzuki)"
                        },
                        new
                        {
                            Id = 28,
                            Abrv = "Lancer",
                            MakeId = 12,
                            Name = "Lancer (Mitsubishi)"
                        },
                        new
                        {
                            Id = 29,
                            Abrv = "Mirage",
                            MakeId = 12,
                            Name = "Mirage (Mitsubishi) "
                        },
                        new
                        {
                            Id = 30,
                            Abrv = "G-Class",
                            MakeId = 13,
                            Name = "G-Class (Mercedes)"
                        },
                        new
                        {
                            Id = 31,
                            Abrv = "Kona",
                            MakeId = 14,
                            Name = "Kona (Kia)"
                        },
                        new
                        {
                            Id = 32,
                            Abrv = "Sportage",
                            MakeId = 14,
                            Name = "Sportage (Kia) "
                        },
                        new
                        {
                            Id = 33,
                            Abrv = "Rio",
                            MakeId = 14,
                            Name = "Rio (Kia)"
                        },
                        new
                        {
                            Id = 34,
                            Abrv = "Qashqai",
                            MakeId = 16,
                            Name = "Qashqai (Nissan)"
                        },
                        new
                        {
                            Id = 35,
                            Abrv = "Juke",
                            MakeId = 16,
                            Name = "Juke (Nissan)"
                        },
                        new
                        {
                            Id = 36,
                            Abrv = "Concept_One",
                            MakeId = 17,
                            Name = "Concept_One 7 (Rimac)"
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
