using System.ComponentModel.DataAnnotations;

namespace BodegaVinos.Entities
{
    public class Wine
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Variety { get; set; } = string.Empty;
        public int Year { get; set; }
        public string Region { get; set; } = string.Empty;

        //cantidad disponible en stock, debe ser mayor o igual a 0
        private int _stock;
        public int Stock
        {
            get => _stock;
            set
            {
                if (value < 0) throw new ArgumentException("El stock no puede ser negativo.");
                _stock = value;
            }
        }
    }
}
