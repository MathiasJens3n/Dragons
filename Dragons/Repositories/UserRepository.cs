using Dragons.Interfaces;
using Dragons.Models;
using System.Diagnostics;

namespace Dragons.Repositories
{
    public class UserRepository : IUserRepository
    {
        public List<User> Users { get; private set; }

        public UserRepository()
        {
            Users = new List<User>() { new User { Name = "Dragon1", Password = "Dragonpsw",Role = RoleEnums.Roles.listener.ToString() } };
        }

        public async Task<bool> AddUser(User user)
        {
            try
            {
                Users.Add(user);
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return false;
            }
        }

        public List<User> GetAllUsers()
        {
            return Users;
        }
    }
}