using System.ComponentModel.DataAnnotations;

namespace BodegaVinos.Entities
{
    public class Cata
    {
        public int Id { get; set; }

        [Required]
        public DateTime Fecha { get; set; }

        [Required]
        public string Nombre { get; set; } = string.Empty;

        // Relación con vinos (muchos a muchos)
        public List<Wine> Vinos { get; set; } = new List<Wine>();

        // Lista de invitados
        public List<string> Invitados { get; set; } = new List<string>();
    }
}
