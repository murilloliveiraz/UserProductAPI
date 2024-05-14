using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using UserProductAPI.Data.DTOS;
using UserProductAPI.Data.Models;

namespace UserProductAPI.Services
{
    public class UserService
    {
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly TokenService _tokenService;

        public UserService(IMapper mapper, UserManager<User> userManager, SignInManager<User> signInManager, TokenService tokenService)
        {
            _mapper = mapper;
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
        }

        public async Task CreateUser(CreateUserDTO userDTO)
        {
            if (!userDTO.ValidateRole())
            {
                throw new ApplicationException("Role deve ser 'admin' ou 'user'.");
            }

            User user = _mapper.Map<User>(userDTO);

            IdentityResult result = await _userManager.CreateAsync(user, userDTO.Password);

            if (!result.Succeeded)
            {
                throw new ApplicationException("Falha ao cadastrar usuário!");
            }
        }

        public async Task<string> LoginUser(LoginUserDTO userDTO)
        {
            var result = await _signInManager.PasswordSignInAsync(userDTO.Username, userDTO.Password, false, false);

            if (!result.Succeeded)
            {
                throw new ApplicationException("Usuário não autenticado");
            }

            var user = _signInManager.UserManager.Users.FirstOrDefault(user => user.NormalizedUserName == userDTO.Username.ToUpper());

            var token = _tokenService.GenerateToken(user);

            return token;
        }
    }
}
