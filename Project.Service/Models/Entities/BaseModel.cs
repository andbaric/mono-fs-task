using System.ComponentModel.DataAnnotations;

namespace Project.Service.Models.Entities
{
    public class BaseModel
    {
        [Key]
        public int Id { get; set; }
    }
}
