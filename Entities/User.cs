using System.ComponentModel.DataAnnotations;

namespace BodegaVinos.Entities
{
    public class User
    {
        //ID único del usuario
        public int Id { get; set; }

        // Nombre de usuario, requerido y único
        [Required]
        public string Username { get; set; } = string.Empty;

        // Contraseña, al menos 8 caracteres
        public required string Password { get; set; } = string.Empty;
    }
}
