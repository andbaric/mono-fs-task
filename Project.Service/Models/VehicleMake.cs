using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Service.Models
{
  [Table("vehicle_make")]
  public class VehicleMake : BaseModel
  {
    public string Name { get; set; }
    public string Abrv { get; set; }
  }
}
