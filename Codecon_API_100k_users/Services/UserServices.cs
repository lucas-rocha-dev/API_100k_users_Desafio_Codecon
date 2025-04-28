using Codecon_API_100k_users.Data;
using Codecon_API_100k_users.Dto;
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

            var superUsers = user.Where(static u => u.Score >= 900 && u.Ativo == true).ToList();



            return superUsers;
        }

        public List<TopCountriesDto> TopCountries(List<User> user)
        {

            var superUser = SuperUsers(user);
            var top5Countries = superUser.GroupBy(static u => u.Pais)
                .Select(static g => new TopCountriesDto { Pais = g.Key, SuperUserCount = g.Count() })
                .OrderByDescending(static g => g.SuperUserCount)
                .Take(5)
                .ToList();



            return top5Countries;
        }

        public List<TeamInsightsDto> TeamInsights(List<User> user)
        {
            var times = user.GroupBy(u => u.Equipe.Nome)
                .Select(grupo => new TeamInsightsDto {
                    Nome = grupo.Key,
                    TotalMembros = grupo.Count(),
                    TotalLideres = grupo.Count(u => u.Equipe.Lider),
                    ProjetosConcluidos = grupo
                    .SelectMany(u => u.Equipe.Projetos)
                    .Where(p => p.Concluido)
                    .Distinct()
                    .Count(),
                    PorcMembrosAtivos = (double)grupo.Count(u => u.Ativo) / grupo.Count() * 100
                }).ToList();





            return times;
        }

        public List<ActivePerDayDto> ActiveUsersPerDay(List<User> user, int minQtdLogin)
        {
            var loginPerData = user.SelectMany(u => u.Logs)
                                    .Where(log => log.Acao == "login")  
                                    .GroupBy(log => log.Data.Date)
                                    .Select(group => new ActivePerDayDto {
                                        Date = group.Key,
                                        QtdLogin = group.Count()
                                    }
                                    
                                    )
                                     .Where(dto => dto.QtdLogin >= minQtdLogin)
                                    .OrderByDescending(dto => dto.QtdLogin)
                                    .ToList();

            return loginPerData;
        }
    }
}
