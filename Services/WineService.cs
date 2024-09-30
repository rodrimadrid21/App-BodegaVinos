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

            _wineRepository.AddWine(wine); //llama al método del repositorio
            return wine;
        }

        public Wine GetWineByName(string name)
        {
            return _wineRepository.GetWineByName(name);
        }

        public Wine UpdateStock(string name, int newStock)
        {
            var wine = _wineRepository.GetWineByName(name);
            if (wine == null)
                return null;

            wine.Stock = newStock;
            return wine;
        }

        public List<Wine> GetAllWines()
        {
            return _wineRepository.GetAllWines();
        }
    }
}