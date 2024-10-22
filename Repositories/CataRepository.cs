using BodegaVinos.Data;
using BodegaVinos.Entities;
using Microsoft.EntityFrameworkCore;

namespace BodegaVinos.Repositories
{
    public class CataRepository
    {
        private readonly BodegaVinosDbContext _context;

        public CataRepository(BodegaVinosDbContext context)
        {
            _context = context;
        }

        //agregar nueva cata
        public async Task AddCataAsync(Cata cata)
        {
            await _context.Catas.AddAsync(cata);
            await _context.SaveChangesAsync();
        }

        //todas las catas
        public async Task<List<Cata>> GetAllCatasAsync()
        {
            return await _context.Catas.Include(c => c.Vinos).ToListAsync();
        }
    }
}

