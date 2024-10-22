using BodegaVinos.Entities;
using BodegaVinos.Repositories;

namespace BodegaVinos.Services
{
    public class CataService
    {
        private readonly CataRepository _cataRepository;

        public CataService(CataRepository cataRepository)
        {
            _cataRepository = cataRepository;
        }

        public async Task AddCataAsync(Cata cata)
        {
            await _cataRepository.AddCataAsync(cata);
        }

        public async Task<List<Cata>> GetAllCatasAsync()
        {
            return await _cataRepository.GetAllCatasAsync();
        }
    }
}
