﻿using System.ComponentModel.DataAnnotations;

namespace Project.Service.Models.DTOs.VehicleAdministration.VehicleModels
{
    public interface IIdentifier
    {
        [Required]
        public int Id { get; set; }
    }
}
