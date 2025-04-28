using Codecon_API_100k_users.Data;
using Codecon_API_100k_users.Dto;

namespace Codecon_API_100k_users.Services
{
    public interface IUserService
    {
        List<User> PostUsers(List<User> users);

        List<User> SuperUsers(List<User> user);
        List<TopCountriesDto> TopCountries(List<User> user);
        List<TeamInsightsDto> TeamInsights(List<User> user);
        List<ActivePerDayDto> ActiveUsersPerDay(List<User> user, int minQtdLogin);
    }
}
