using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models.DTOs
{
    public class RegisterationRequestDto
    {
        [Required]
        public String? Username { get; set; }
        [Required]
        public String? Email { get; set; }
        [Required]
        public String? Password { get; set; }

        public Boolean isAdmin = false;
    }
}
