using Dragons.Models;

namespace Dragons.Interfaces
{
    public interface IUserRepository
    {
        public Task<bool> AddUser(User user);

        public List<User> GetAllUsers();

        public User Getuser(string name, string password);
    }
}