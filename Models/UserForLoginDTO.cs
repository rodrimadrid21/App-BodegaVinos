using System.ComponentModel.DataAnnotations;

namespace BodegaVinos.Models
{
    public class UserForLoginDTO
    {
        [Required(ErrorMessage = "El nombre de usuario es obligatorio.")]
        public string Username { get; set; } = string.Empty;

        [Required(ErrorMessage = "La contraseña es obligatoria.")]
        [MinLength(8)]
        public string Password { get; set; } = string.Empty;
    }
}
