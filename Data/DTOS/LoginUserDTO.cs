using System.ComponentModel.DataAnnotations;

namespace UserProductAPI.Data.DTOS
{
    public class LoginUserDTO
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
