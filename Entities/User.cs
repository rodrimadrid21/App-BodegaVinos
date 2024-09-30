using System.ComponentModel.DataAnnotations;

namespace BodegaVinos.Entities
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        public string Username { get; set; } = string.Empty;
        [Required]
        public required string Password { get; set; } = string.Empty;
    }
}
