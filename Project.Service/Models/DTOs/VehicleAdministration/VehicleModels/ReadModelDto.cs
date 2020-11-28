
using System.ComponentModel.DataAnnotations;

namespace Project.Service.Models.DTOs.VehicleAdministration.VehicleModels
{
    public class ReadModelDto : IIdentifier
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Abrv { get; set; }

        public int MakeId { get; set; }
        [Display(Name="Make name")]
        public string MakeName { get; set; }
    }
}
