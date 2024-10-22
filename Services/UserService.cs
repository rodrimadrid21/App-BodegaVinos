using BodegaVinos.Data;
using BodegaVinos.Entities;
using BodegaVinos.Models;
using BodegaVinos.Repositories;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BCrypt.Net;

namespace BodegaVinos.Services
{
    public class UserService
    {
        private readonly UserRepository _userRepository;
        private readonly IConfiguration _configuration;

        public UserService(UserRepository userRepository, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _configuration = configuration;
        }

        //agrega un usuario
        public async Task<User> AddUserAsync(UserForLoginDTO userDTO)
        {
            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(userDTO.Password); //Hashea la contraseña
            var user = new User
            {
                Username = userDTO.Username,
                Password = hashedPassword//se usa la contraseña hashead
            };

            await _userRepository.AddUserAsync(user); //guarda al usuario en la bdd
            return user;
        }

        //genera un token JWT para autenticar al usuario
        public string GenerateJwtToken(User user)
        {
            var claims = new[]
            {
            new Claim(JwtRegisteredClaimNames.Sub, user.Username),//nombre
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())//id unico del token
        };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:SecretKey"]));//clave secreta
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);//credenciales de firma

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],// BodegaVinosAPI
                audience: _configuration["Jwt:Audience"],// BodegaVinosUsers
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),//valido hasta 30 min(expira)
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);//retorna cadena de texto token
        }

        //validacion
        public async Task<User> ValidateUserAsync(string username, string password)
        {
            var user = await _userRepository.GetUserByUsernameAsync(username);//verif q exista por nombre
            if (user == null || !BCrypt.Net.BCrypt.Verify(password, user.Password)) //compara la contraseña ingresada con la hasheada
            {
                return null;
            }
            return user;
        }
    }
}
