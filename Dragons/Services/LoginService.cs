using Dragons.Interfaces;
using Dragons.Models;
using System.Diagnostics;

namespace Dragons.Services
{
    public static class LoginService
    {
        public static User ValidateLogin(User user, IUserRepository userRepository)
        {
            try
            {
                var authendicatedUser = userRepository.GetAllUsers().FirstOrDefault(x => x.Name == user.Name && x.Password == user.Password, null);

                if (authendicatedUser != null)
                {
                    return authendicatedUser;
                }
                return null;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return null;
            }
        }
    }
}