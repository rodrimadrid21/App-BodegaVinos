using BodegaVinos.Entities;

namespace BodegaVinos.Repositories
{
    public class UserRepository
    {
        private List<User> _users = new List<User>();  // Lista en memoria de usuarios

        public void AddUser(User user)
        {
            _users.Add(user);
        }

        public User GetUserByUsername(string username)
        {
            return _users.FirstOrDefault(u => u.Username.Equals(username, System.StringComparison.OrdinalIgnoreCase));
        }
    }
}
