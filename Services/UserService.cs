using BodegaVinos.Data;
using BodegaVinos.Entities;
using BodegaVinos.Models;

namespace BodegaVinos.Services
{
    public class UserService
    {
        private readonly BodegaVinosDbContext _context;

        public UserService(BodegaVinosDbContext context)
        {
            _context = context;
        }

        public User AddUser(UserForCreationDTO userDto)
        {
            var user = new User
            {
                Username = userDto.Username,
                Password = userDto.Password // Asegúrate de hashear la contraseña en una implementación real
            };

            _context.Users.Add(user);
            _context.SaveChanges();

            return user;
        }

        internal void AddUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}
