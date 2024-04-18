using System.ComponentModel.DataAnnotations;
using TPMoraCapdevila1.Data.Entities;

namespace TPMoraCapdevila1.Data.Models
{
    public class UserDTO
    {
        [Required(ErrorMessage = "Name is required")]
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Adress { get; set; }

        
    }
}
