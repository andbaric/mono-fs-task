﻿
namespace Project.Service.Models.DTOs.VehicleAdministration.VehicleModels
{
    public class ReadModelsDto : IIdentifier
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Abrv { get; set; }

        public int MakeId { get; set; }
        public string MakeName { get; set; }
        
    }
}
