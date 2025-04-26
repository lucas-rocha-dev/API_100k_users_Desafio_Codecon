using Codecon_API_100k_users.Data;

namespace Codecon_API_100k_users.Services
{
    public interface IUserService
    {
        List<User> PostUsers(List<User> users);

        public List<User> SuperUsers(List<User> user);
        List<string> TopCountries(List<User> user);
    }
}
