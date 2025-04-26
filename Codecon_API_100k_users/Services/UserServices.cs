using Codecon_API_100k_users.Data;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Threading;

namespace Codecon_API_100k_users.Services
{
    public class UserServices : IUserService
    {

        public List<User> PostUsers(List<User> users)
        {
            return users;
        }

        

        public List<User> SuperUsers(List<User> user)
        {
           


            return new List<User> {

            };
        }
        public List<string> TopCountries(List<User> user)
        {
            var top5Countries = user.GroupBy(static u => u.Pais)
                .Select(static g => new { Pais = g.Key, Count = g.Count() })
                .OrderByDescending(static g => g.Count)
                .Take(5)
                .ToList();

            List<string> paises = new();
            foreach (var country in top5Countries) {
                paises.Add(country.Pais);
            }

            return paises;
        }
    }
}
