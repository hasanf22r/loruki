using System.ComponentModel.DataAnnotations;

namespace Api.DTOs
{
    public class LoginDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
    public class RegisterDto
    {
        public string Username { get; set; }

        [Required]
        public string Email { get; set; }


        [Required]
        [Compare(nameof(RePassword))]
        public string Password { get; set; }
        
        [Required]
        public string RePassword { get; set; }
    
    }
}