using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using UserProductAPI.Data.DTOS;
using UserProductAPI.Services;

namespace UserProductAPI.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class UsersController: ControllerBase
    {
        private UserService _userService;

        public UsersController(UserService userService)
        {
            _userService = userService;
        }

        [HttpPost("signup")]
        public async Task<IActionResult> CreateUser(CreateUserDTO userDTO)
        {
            await _userService.CreateUser(userDTO);
            return Ok("Usuário criado com sucesso");
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginUser(LoginUserDTO userDTO)
        {
            var token = await _userService.LoginUser(userDTO);
            return Ok(token);
        }
    }
}
