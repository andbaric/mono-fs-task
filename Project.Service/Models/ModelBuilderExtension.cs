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
            new VehicleMake { Id = 325, Name = "BMW", Abrv = "BMW" },
            new VehicleMake { Id = 100, Name = "Ford", Abrv = "Ford" },
            new VehicleMake { Id = 200, Name = "Volkswagen", Abrv = "VW" }
            };
            modelBuilder.Entity<VehicleMake>().HasData(vehicleMakes);

            var vehicleModels = new List<VehicleModel>
            {
                new VehicleModel { Id = 128, MakeId = 325, Name = "X5 (BMW)", Abrv = "X5" },
                new VehicleModel { Id = 2, MakeId = 200, Name = "Golf 6 (VW) ", Abrv = "Golf 6" },
                new VehicleModel { Id = 3, MakeId = 200, Name = "Golf 7 (VW)", Abrv = "Golf 7" }
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
