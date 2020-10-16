using Microsoft.EntityFrameworkCore;

namespace Project.Service.Models
{
      public class VehicleDbContext: DbContext
      {
            public DbSet<VehicleMake> VehicleMakes { get; set; }
            public DbSet<VehicleModel> VehicleModels { get; set; }

            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
              => optionsBuilder
              .UseMySql(
                "User=root;Password=aiq&m5%SJk;Server=localhost;Port=3306;Database=vehicle_db;"
              );
    
            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                modelBuilder.DecribeRelationships();
                modelBuilder.SeedData();
            }
      }
}
