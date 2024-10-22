using BodegaVinos.Entities;
using BodegaVinos.Models;
using BodegaVinos.Repositories;

namespace BodegaVinos.Services
{
    public class WineService
    {
        private readonly WineRepository _wineRepository;

        public WineService(WineRepository wineRepository)
        {
            _wineRepository = wineRepository;
        }

        public async Task<Wine> AddWineAsync(WineForCreationDTO wineDto)
        {
            var wine = new Wine
            {
                Name = wineDto.Name,
                Variety = wineDto.Variety,
                Year = wineDto.Year,
                Region = wineDto.Region,
                Stock = wineDto.Stock
            };

            await _wineRepository.AddWineAsync(wine);
            return wine;
        }
        //conseguir todos
        public async Task<List<Wine>> GetAllWinesAsync()
        {
            return await _wineRepository.GetAllWinesAsync();
        }

        //conseguir vinos por variedad
        public async Task<List<Wine>> GetWinesByVarietyAsync(string variety)
        {
            return await _wineRepository.GetWinesByVarietyAsync(variety);
        }
        //conseguir por id
        public async Task<Wine> GetWineByIdAsync(int id)
        {
            return await _wineRepository.GetWineByIdAsync(id);
        }

        // actualizar stock
        public async Task UpdateWineStockAsync(int id, int newStock)
        {
            await _wineRepository.UpdateWineStockAsync(id, newStock);
        }

    }
}
