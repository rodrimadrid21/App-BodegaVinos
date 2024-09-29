using BodegaVinos.Entities;
using Microsoft.EntityFrameworkCore;

namespace BodegaVinos.Data
{
    public class BodegaVinosDbContext : DbContext
    {
        //constructor
        public BodegaVinosDbContext(DbContextOptions<BodegaVinosDbContext> options) : base(options)
        {
        }

        public DbSet<Wine> Wines { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Aquí puedes agregar configuraciones adicionales si es necesario
            base.OnModelCreating(modelBuilder);
        }
    }
}
