using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Project.Service.Models
{
    public static class ModelBuilderExtension
    {
        public static void SeedData(this ModelBuilder modelBuilder)
        {
            var vehicleMakes = new List<VehicleMake>
            {
                new VehicleMake { Id = 1, Name = "Bayerische Motoren Werke", Abrv = "BMW" },
                new VehicleMake { Id = 2, Name = "Volkswagen", Abrv = "VW" },
                new VehicleMake { Id = 3, Name = "Opel", Abrv = "Opel" },
                new VehicleMake { Id = 4, Name = "Audi", Abrv = "Audi" },
                new VehicleMake { Id = 5, Name = "Renault", Abrv = "Renault" },
                new VehicleMake { Id = 6, Name = "Ford", Abrv = "Ford" },
                new VehicleMake { Id = 7, Name = "Peugeot", Abrv = "Peugeot" },
                new VehicleMake { Id = 8, Name = "Mazda", Abrv = "Mazda" },
                new VehicleMake { Id = 9, Name = "Toyota", Abrv = "Toyota" },
                new VehicleMake { Id = 10, Name = "Honda", Abrv = "Honda" },
                new VehicleMake { Id = 11, Name = "Suzuki", Abrv = "Suzuki" },
                new VehicleMake { Id = 12, Name = "Mitsubishi", Abrv = "Mitsubishi" },
                new VehicleMake { Id = 13, Name = "Mercedes-Benz", Abrv = "Mercedes" },
                new VehicleMake { Id = 14, Name = "Kia", Abrv = "Kia" },
                new VehicleMake { Id = 15, Name = "Hyundai", Abrv = "Hyundai" },
                new VehicleMake { Id = 16, Name = "Nissan", Abrv = "Nissan" },
                new VehicleMake { Id = 17, Name = "Rimac", Abrv = "Rimac" },
            };
            modelBuilder.Entity<VehicleMake>().HasData(vehicleMakes);

            var vehicleModels = new List<VehicleModel>
            {
                new VehicleModel { Id= 1, MakeId = 1, Name = "X5 (BMW)", Abrv = "X5" },
                new VehicleModel { Id= 2, MakeId = 1, Name = "M4 (BMW)", Abrv = "M4" },
                new VehicleModel { Id= 3, MakeId = 2, Name = "Golf 7 (VW)", Abrv = "Golf 7" },
                new VehicleModel { Id= 4, MakeId = 2, Name = "Pasat (VW)", Abrv = "Pasat" },
                new VehicleModel { Id= 5, MakeId = 2, Name = "Arteon (VW) ", Abrv = "Arteon" },
                new VehicleModel { Id= 6, MakeId = 3, Name = "Corsa (Opel)", Abrv = "Corsa" },
                new VehicleModel { Id= 7, MakeId = 4, Name = "A4 (Audi)", Abrv = "A4" },
                new VehicleModel { Id= 8, MakeId = 4, Name = "Q5 (Audi) ", Abrv = "Q5" },
                new VehicleModel { Id= 9, MakeId = 4, Name = "Q7 (Audi)", Abrv = "Q7" },
                new VehicleModel { Id= 10, MakeId = 5, Name = "Megane (Renault)", Abrv = "Megane" },
                new VehicleModel { Id= 11, MakeId = 5, Name = "Clio (Renault) ", Abrv = "Renault" },
                new VehicleModel { Id= 12, MakeId = 6, Name = "Mondeo (Ford)", Abrv = "Mondeo" },
                new VehicleModel { Id= 13, MakeId = 6, Name = "Mustang (Ford)", Abrv = "Mustang" },
                new VehicleModel { Id= 14, MakeId = 6, Name = "Fiesta (Ford) ", Abrv = "Fiesta" },
                new VehicleModel { Id= 15, MakeId = 6, Name = "Focus (Ford)", Abrv = "Focus" },
                new VehicleModel { Id= 16, MakeId = 7, Name = "206 (Peugeot)", Abrv = "206" },
                new VehicleModel { Id= 17, MakeId = 8, Name = "6 (Mazda)", Abrv = "6" },
                new VehicleModel { Id= 18, MakeId = 8, Name = "3 (Mazda)", Abrv = "3" },
                new VehicleModel { Id= 19, MakeId = 9, Name = "RAV4 (Toyota)", Abrv = "RAV4" },
                new VehicleModel { Id= 20, MakeId = 9, Name = "Corola (Toyota) ", Abrv = "Corola" },
                new VehicleModel { Id= 21, MakeId = 9, Name = "Yaris (Toyota)", Abrv = "Yaris" },
                new VehicleModel { Id= 22, MakeId = 9, Name = "Auris (Toyota)", Abrv = "Auris" },
                new VehicleModel { Id= 23, MakeId = 10, Name = "CR-V (Honda)", Abrv = "CR-V" },
                new VehicleModel { Id= 24, MakeId = 10, Name = "Accord (Honda)", Abrv = "Accord" },
                new VehicleModel { Id= 25, MakeId = 11, Name = "Swift (Suzuki)", Abrv = "SWIFT" },
                new VehicleModel { Id= 26, MakeId = 11, Name = "Ignis (Suzuki) ", Abrv = "Ignis" },
                new VehicleModel { Id= 27, MakeId = 11, Name = "Jimny 7 (Suzuki)", Abrv = "Jimny" },
                new VehicleModel { Id= 28, MakeId = 12, Name = "Lancer (Mitsubishi)", Abrv = "Lancer" },
                new VehicleModel { Id= 29, MakeId = 12, Name = "Mirage (Mitsubishi) ", Abrv = "Mirage" },
                new VehicleModel { Id= 30, MakeId = 13, Name = "G-Class (Mercedes)", Abrv = "G-Class" },
                new VehicleModel { Id= 31, MakeId = 14, Name = "Kona (Kia)", Abrv = "Kona" },
                new VehicleModel { Id= 32, MakeId = 14, Name = "Sportage (Kia) ", Abrv = "Sportage" },
                new VehicleModel { Id= 33, MakeId = 14, Name = "Rio (Kia)", Abrv = "Rio" },
                new VehicleModel { Id= 34, MakeId = 16, Name = "Qashqai (Nissan)", Abrv = "Qashqai" },
                new VehicleModel { Id= 35, MakeId = 16, Name = "Juke (Nissan)", Abrv = "Juke" },
                new VehicleModel { Id= 36, MakeId = 17, Name = "Concept_One 7 (Rimac)", Abrv = "Concept_One" },
            };
            modelBuilder.Entity<VehicleModel>().HasData(vehicleModels);
        }

        public static void DecribeRelationships(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VehicleModel>()
                .HasOne<VehicleMake>()
                .WithMany()
                .HasForeignKey(p => p.MakeId);
        }
    }
}
