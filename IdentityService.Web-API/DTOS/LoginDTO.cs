using System.ComponentModel.DataAnnotations;


namespace IdentityService.Web_API.DTOS
{
    public class LoginDto
    {
        [Required]
        public string? UserName { get; set; }
        [Required]
        public string? Password { get; set; }
    }
}
