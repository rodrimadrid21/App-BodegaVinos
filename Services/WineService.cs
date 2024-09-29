using BodegaVinos.Entities;
using BodegaVinos.Models;
using BodegaVinos.Repositories;
using Microsoft.EntityFrameworkCore;
using BodegaVinos.Data;

namespace BodegaVinos.Services
{
    public class WineService
    {
        private readonly WineRepository _wineRepository;

        public WineService(WineRepository wineRepository)
        {
            _wineRepository = wineRepository;
        }

        public Wine AddWine(WineForCreationDTO wineDto)
        {
            var wine = new Wine
            {
                Name = wineDto.Name,
                Variety = wineDto.Variety,
                Year = wineDto.Year,
                Region = wineDto.Region,
                Stock = wineDto.Stock
            };

            _wineRepository.AddWine(wine); // Llamar al método del repositorio
            return wine;
        }

        public Wine GetWineByName(string name)
        {
            return _wineRepository.GetWineByName(name); // Usar el repositorio
        }

        public Wine UpdateStock(string name, int newStock) // Cambia el parámetro a string para buscar por nombre
        {
            var wine = _wineRepository.GetWineByName(name);
            if (wine == null)
                return null;

            wine.Stock = newStock; // Actualizar stock directamente en el objeto
            return wine; // No se necesita guardar en el repositorio porque no hay base de datos
        }

        public List<Wine> GetAllWines()
        {
            return _wineRepository.GetAllWines(); // Usar el repositorio
        }
    }
}