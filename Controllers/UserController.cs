using BodegaVinos.Entities;
using BodegaVinos.Models;
using BodegaVinos.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BodegaVinos.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        //Registrar nuevo usuario
        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser([FromBody] UserForLoginDTO userDTO)
        {
            // Validación de campos obligatorios
            if (string.IsNullOrEmpty(userDTO.Username))
            {
                return BadRequest("El nombre de usuario es obligatorio.");
            }

            if (string.IsNullOrEmpty(userDTO.Password))
            {
                return BadRequest("La contraseña es obligatoria.");
            }

            // Llama al servicio para agregar el usuario
            await _userService.AddUserAsync(userDTO);
            return Ok("Usuario registrado con éxito.");
        }
        //logearse
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserForLoginDTO loginDto)
        {
            var user = await _userService.ValidateUserAsync(loginDto.Username, loginDto.Password);
            if (user == null)
            {
                return Unauthorized("Usuario o contraseña inválidos.");
            }

            var token = _userService.GenerateJwtToken(user);
            return Ok(new { Token = token });
        }
    }
}
