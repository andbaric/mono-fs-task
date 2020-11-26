using System.ComponentModel.DataAnnotations;

namespace Project.Service.Models.DTOs.VehicleAdministration.VehicleModels
{
    public class CreateModelDto
    { 
        [Required]
        public string Name { get; set; }
        [Required]
        public string Abrv { get; set; }

        public int MakeId { get; set; }
    }
}
