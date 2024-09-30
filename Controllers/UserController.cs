using BodegaVinos.Entities;
using BodegaVinos.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BodegaVinos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public IActionResult RegisterUser([FromBody] User user)
        {
            //validación de campos obligatorios
            if (string.IsNullOrEmpty(user.Username))
            {
                return BadRequest("El nombre de usuario es obligatorio.");
            }

            if (string.IsNullOrEmpty(user.Password))
            {
                return BadRequest("La contraseña es obligatoria.");
            }

            _userService.AddUser(user);
            return Ok("Usuario registrado con éxito.");
        }
    }
}
