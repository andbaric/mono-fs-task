using Microsoft.EntityFrameworkCore;

namespace Project.Service.Models
{
  public static class ModelBuilderExtension
  {
     public static void DecribeRelationships(this ModelBuilder modelBuilder)
     {
      modelBuilder.Entity<VehicleModel>()
        .HasOne<VehicleMake>()
        .WithMany()
        .HasForeignKey(p => p.MakeId);
     }
  }
}
