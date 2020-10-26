using System.ComponentModel.DataAnnotations;

namespace Project.MVC.Models
{
    public class AdministrationViewModel
    {
        [Required]
        public string Title { get; set; }
    }
}
