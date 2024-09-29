using System.ComponentModel.DataAnnotations;

namespace BodegaVinos.Models
{
    public class WineForCreationDTO
    {
        // Nombre del vino, requerido
        [Required(ErrorMessage = "El nombre del vino es obligatorio.")]
        public string Name { get; set; } = string.Empty;

        // Variedad del vino, requerido
        [Required(ErrorMessage = "La variedad del vino es obligatoria.")]
        public string Variety { get; set; } = string.Empty;

        // Año de producción, requerido
        [Required(ErrorMessage = "El año de producción es obligatorio.")]
        public int Year { get; set; }

        // Región del vino, requerido
        [Required(ErrorMessage = "La región es obligatoria.")]
        public string Region { get; set; } = string.Empty;

        // Cantidad en stock, requerido
        [Required(ErrorMessage = "La cantidad en stock es obligatoria.")]
        public int Stock { get; set; }
    }
}
