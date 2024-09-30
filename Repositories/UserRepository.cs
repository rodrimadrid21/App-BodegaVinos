using BodegaVinos.Entities;

namespace BodegaVinos.Repositories
{
    public class UserRepository
    {
        private List<User> _users = new List<User>();  //lista de usuarios

        public void AddUser(User user)
        {
            _users.Add(user);
        }
    }
}
