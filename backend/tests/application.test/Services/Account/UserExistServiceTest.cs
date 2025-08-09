using application.Services.Account;
using domain.Entities;
using domain.Interfaces.UsersInterfaces;
using Bogus;
using Moq;

namespace application.test.Services.Account
{
    public class UserExistServiceTest
    {
        // mockar o banco de dados
        // se o usuário mandar string email ->  retornar null

        [Fact]
        public async Task ByEmail_ShouldReturnFalse_WhenUserExist()
        {
            // Arrange

            // Cria um email aleatório, seguindo o Test Data Builder Pattern
            var email = new Faker().Internet.Email();

            var mockRepo =
                // Mock da dependência que manipula o repositório
                new Mock<IUserRepository>();

            mockRepo.Setup(repo => repo.FindUserByEmail(email))
                .ReturnsAsync((User)null);

            var service = new UserExistService(mockRepo.Object);

            // Act

            // Simula a injeção de dependência
            var UserExistService = new UserExistService(mockRepo.Object);

            var result = await service.ByEmail(email);

            // Assert
            Assert.False(result);
        }
    }
}
