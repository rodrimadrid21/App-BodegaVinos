using System.ComponentModel.DataAnnotations;

namespace BodegaVinos.Models
{
    public class UserForCreationDTO
    {
        [Required(ErrorMessage = "El ID es obligatorio.")]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre de usuario es obligatorio.")]
        public string Username { get; set; } = string.Empty;

        //8 caracteres
        [Required(ErrorMessage = "La contraseña es obligatoria.")]
        [MinLength(8)]
        public required string Password { get; set; } = string.Empty;
    }
}

