using BodegaVinos.Data;
using BodegaVinos.Entities;
using Microsoft.EntityFrameworkCore;

namespace BodegaVinos.Repositories
{
    public class UserRepository
    {
        private readonly BodegaVinosDbContext _context; //declara el contexto de la bdd

        public UserRepository(BodegaVinosDbContext context) //constructor
        {
            _context = context;
        }

        //agregar un nuevo usuario
        public async Task AddUserAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync(); // Guarda los cambios en la BDD
        }
        //buscar un usuario por su nombre de usuario
        public async Task<User> GetUserByUsernameAsync(string username)
        {
            return await _context.Users
                .FirstOrDefaultAsync(u => u.Username == username); //lo busca por username
        }
        //verifica si el usuario existe
        public async Task<bool> UserExistsAsync(string username)
        {
            return await _context.Users.AnyAsync(u => u.Username == username); //verif
        }
    }
}
