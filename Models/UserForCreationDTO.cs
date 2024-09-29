using System.ComponentModel.DataAnnotations;

namespace BodegaVinos.Models
{
    public class UserForCreationDTO
    {
        //ID único del usuario
        [Required(ErrorMessage = "El ID es obligatorio.")]
        public int Id { get; set; }

        // Nombre de usuario, requerido y único
        [Required(ErrorMessage = "El nombre de usuario es obligatorio.")]
        public string Username { get; set; } = string.Empty;

        // Contraseña, al menos 8 caracteres
        [Required(ErrorMessage = "La contraseña es obligatoria.")]
        [MinLength(8)]
        public required string Password { get; set; } = string.Empty;
    }
}

