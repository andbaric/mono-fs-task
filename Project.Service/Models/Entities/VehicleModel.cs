using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Service.Models.Entities
{
    [Table("vehicle_model")]
    public class VehicleModel : BaseModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Abrv { get; set; }

        [Required]
        public int MakeId { get; set; }
    }
}