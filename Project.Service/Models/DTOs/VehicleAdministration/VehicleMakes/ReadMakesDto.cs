namespace Project.Service.Models.DTOs.VehicleAdministration.VehicleMakes
{
    public class ReadMakesDto : IIdentifier
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Abrv { get; set; }
    }
}
