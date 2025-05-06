namespace Test_API_100k_users { 
using Codecon_API_100k_users;
using Codecon_API_100k_users.Data;
using Codecon_API_100k_users.Services;

    [TestClass]
    public sealed class Test_API_100k_users 
    {
        // Arrange
        List<User> user = new List<User> {
                new User {
                    Nome = "João",
                    Idade = 25,
                    Score = 950,
                    Ativo = true,
                    Pais = "Brasil"
                }
            };
        UserServices userService = new UserServices();

        [TestMethod]
        public void TestPostUsers()
        {

            // Act
            List<User> result = userService.PostUsers(user);
            Assert.IsNotNull(result[0]);
            Assert.AreEqual("João", result[0].Nome);

        }
    }
}
