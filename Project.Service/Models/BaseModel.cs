using System.ComponentModel.DataAnnotations;

namespace Project.Service.Models
{
    public class BaseModel
    {
        [Key]
        public int Id { get; set; }
    }
}
