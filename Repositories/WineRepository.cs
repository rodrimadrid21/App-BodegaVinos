using BodegaVinos.Data;
using BodegaVinos.Entities;
using Microsoft.EntityFrameworkCore;

namespace BodegaVinos.Repositories
{
    public class WineRepository
    {
        private readonly BodegaVinosDbContext _context;

        public WineRepository(BodegaVinosDbContext context)
        {
            _context = context; //asigna el contexto
        }

        //lista de todos los vinos
        public async Task<List<Wine>> GetAllWinesAsync()
        {
            return await _context.Wines.ToListAsync();
        }

        //agregar un vino
        public async Task AddWineAsync(Wine wine)
        {
            await _context.Wines.AddAsync(wine);
            await _context.SaveChangesAsync();
        }

        //conseguir vinos por variedad
        public async Task<List<Wine>> GetWinesByVarietyAsync(string variety)
        {
            return await _context.Wines
                .Where(w => w.Variety == variety)
                .ToListAsync(); //Devuelve la lista de vinos que coinciden con la variedad
        }

        //conseguir un vino por id
        public async Task<Wine> GetWineByIdAsync(int id)
        {
            return await _context.Wines.FindAsync(id);
        }

        //actualizar el stock
        public async Task UpdateWineStockAsync(int id, int newStock)
        {
            var wine = await _context.Wines.FirstOrDefaultAsync(w => w.Id == id);
            if (wine != null)
            {
                wine.Stock = newStock; // Actualiza el stock
                await _context.SaveChangesAsync(); // Guarda los cambios en la BDD
            }
        }
    }
}
