
namespace Project.Service.Models.DTOs.VehicleAdministration.VehicleMakes
{
    // pagable
    public class ReadMakesDto
    {
        // filterable, sortable, custom data anotations
        public string Name { get; set; }
        // filterable, sortable, custom data anotations
        public string Abrv { get; set; }
    }
}
