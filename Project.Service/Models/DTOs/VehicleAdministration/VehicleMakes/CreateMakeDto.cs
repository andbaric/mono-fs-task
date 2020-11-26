using System.ComponentModel.DataAnnotations;

namespace Project.Service.Models.DTOs.VehicleAdministration.VehicleMakes
{
    public class CreateMakeDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Abrv { get; set; }
    }
}
