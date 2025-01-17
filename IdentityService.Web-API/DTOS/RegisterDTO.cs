using System.ComponentModel.DataAnnotations;

namespace IdentityService.Web_API.DTOS
{
    public class RegisterDTO
    {

        [Required]
        public string? UserName { get; set; }
        [Required]
        public string? Name { get; set; }
       
        [Required]
        public string? Email { get; set; }
        [Required]
        public string? Password { get; set; }
        [Required]
        public string? Surname { get; set; }

    }
}
