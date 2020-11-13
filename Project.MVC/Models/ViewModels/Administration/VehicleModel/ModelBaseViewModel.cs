using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project.MVC.Models.ViewModels.Administration.VehicleModel
{
    public class ModelBaseViewModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Abrv { get; set; }

        [Required]
        public string MakeId { get; set; }
        [Required]
        public string MakeName { get; set; }
    }
}
