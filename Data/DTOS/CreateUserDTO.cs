using System.ComponentModel.DataAnnotations;

namespace UserProductAPI.Data.DTOS
{
    public class CreateUserDTO
    {
        [Required(ErrorMessage = "É necessário informar o nome do usuário.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "É necessário informar a role do usuário.")]
        public string Role { get; set; }

        [Required(ErrorMessage = "É necessário informar uma senha.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage ="As senhas não conferem")]
        public string RePassword { get; set; }

        private string ValidateRole()
        {
            string[] validRoles = { "admin", "user" };

            if (Role == null || Array.IndexOf(validRoles, Role.ToLower()) == -1)
            {
                return "Role must be either 'admin' or 'user'.";
            }

            return null; // Retorna null se a role for válida
        }
    }
}
