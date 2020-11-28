using System.ComponentModel.DataAnnotations;

namespace Project.MVC.Models.ViewModels.Administration.Make
{
    public class MakeBaseViewModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Abrv { get; set; }
    }
}
