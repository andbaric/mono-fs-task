using Microsoft.EntityFrameworkCore;
using Project.Service.Helpers;
using Project.Service.Models.Entities;

namespace Project.Service.Models
{
      public class VehicleDbContext: DbContext
      {
            public VehicleDbContext(DbContextOptions<VehicleDbContext> options) : base(options)
            {
            }

            public DbSet<VehicleMake> VehicleMakes { get; set; }
            public DbSet<VehicleModel> VehicleModels { get; set; }
    
            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                modelBuilder.DecribeRelationships();
                modelBuilder.SeedData();
            }
    }
}
