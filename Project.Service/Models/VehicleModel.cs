using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Service.Models
{
  [Table("vehicle_model")]
  public class VehicleModel : BaseModel
  {
    public string Name { get; set; }
    public string Abrv { get; set; }

    public int MakeId { get; set; }
  }
}
