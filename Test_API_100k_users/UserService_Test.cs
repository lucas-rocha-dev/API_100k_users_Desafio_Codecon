namespace Test_API_100k_users { 
using Codecon_API_100k_users.Data;
using Codecon_API_100k_users.Dto;
using Codecon_API_100k_users.Services;

    [TestClass]
    public sealed class UserService_Test 
    {
        // Arrange
        List<User> user = new List<User> {
                new User {
                    Nome = "João",
                    Idade = 25,
                    Score = 950,
                    Ativo = true,
                    Pais = "Brasil",
                    Equipe = new Equipe {
                        Nome = "Equipe A",
                        Lider = true,
                        Projetos = new List<Projetos> {
                            new Projetos { Nome = "Projeto 1", Concluido = true },
                            new Projetos { Nome = "Projeto 2", Concluido = false }
                        }
                    },
                    Logs = new List<Log> {
                        new Log { Data = new DateTime(1991, 08, 20), Acao = "login" },
                        new Log { Data =  new DateTime(2007, 10, 07), Acao = "logout" }
                    }
                }
            };

        private IUserService _userService = new UserServices();

        [TestMethod]
        public void TestPostUsers()
        {
            // Act
            List<User> result = _userService.PostUsers(user);
            //Assert
            Assert.IsNotNull(result[0]);
            Assert.AreEqual("João", result[0].Nome);

        }

        [TestMethod]
        public void SuperUsers()
        {
            // Act
            List<User> result = _userService.SuperUsers(user);
            //Assert
            Assert.IsNotNull(result[0]);
            Assert.AreEqual("João", result[0].Nome);

        }

        [TestMethod]
        public void TopCountries()
        {
            // Act
            List<TopCountriesDto> result = _userService.TopCountries(user);
            //Assert
            Assert.IsNotNull(result[0]);
            Assert.AreEqual("Brasil", result[0].Pais);
        }

        [TestMethod]
        public void TeamInsights()
        {
            // Act
            List<TeamInsightsDto> result = _userService.TeamInsights(user);
            //Assert
            Assert.IsNotNull(result[0]);
            Assert.AreEqual("Equipe A", result[0].Nome);

        }
        [TestMethod]
        public void ActiveUsersPerDay()
        {
            // Act
            List<ActivePerDayDto> result = _userService.ActiveUsersPerDay(user,1);
            //Assert
            Assert.IsNotNull(result[0]);
            Assert.AreEqual(new DateTime(1991, 08, 20), result[0].Date);

        }


    }
}
