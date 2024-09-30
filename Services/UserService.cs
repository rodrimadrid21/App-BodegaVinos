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

        public User AddUser(UserForCreationDTO userDTO)
        {
            var user = new User
            {
                Username = userDTO.Username,
                Password = userDTO.Password
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
