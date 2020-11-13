using System.ComponentModel.DataAnnotations;

namespace Project.MVC.Models.ViewModels
{
    public class VehicleModelViewModel
    {   
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Abrv { get; set; }
        [Required]
        public string MakeName { get; set; }
    }
}
