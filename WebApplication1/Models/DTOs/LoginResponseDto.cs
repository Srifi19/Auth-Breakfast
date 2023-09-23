namespace WebApplication1.Models.DTOs
{
    public class LoginResponseDto
    {
        public String? UserId { get; set; }
        public String? UserName { get; set; }
        public bool isAdmin = false;
    }
}
