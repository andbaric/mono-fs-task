using System.ComponentModel.DataAnnotations;

namespace Project.Service.Models.DTOs.VehicleAdministration.VehicleModels
{
    public class UpdateModelDto : IIdentifier
    {
        public int Id { get; set; }
        [Required]
        public int Name { get; set; }
        [Required]
        public int Abrv { get; set; }

        [Required]
        public int MakeId { get; set; }
        public int MakenName { get; set; }
    }
}
