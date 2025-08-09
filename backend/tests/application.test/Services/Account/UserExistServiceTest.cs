using application.Services.Account;
using application.test.Utilities.UserMock;
using Bogus;
using domain.Entities;
using domain.Interfaces.UsersInterfaces;
using Moq;

namespace application.test.Services.Account
{
    public class UserExistServiceTest
    {
        // mockar o banco de dados
        // se o usuário mandar string email ->  retornar null

        [Fact(DisplayName = "Retorna FALSE se o usuário com o EMAIL não existir")]
        public async Task ByEmail_ShouldReturnFalse_WhenUserDoesntExist()
        {
            // Arrange

            // Cria um email aleatório, seguindo o Test Data Builder Pattern
            var email = new Faker().Internet.Email();

            var mockRepo =
                // Mock da dependência que manipula o repositório
                new Mock<IUserRepository>();

            mockRepo.Setup(repo => repo.FindUserByEmail(email))
                .ReturnsAsync((User)null!);

            // Simula a injeção de dependência
            var service = new UserExistService(mockRepo.Object);

            // Act
            var result = await service.ByEmail(email);

            // Assert
            Assert.False(result);
        }

        [Fact(DisplayName = "Retorna FALSE se o usuário com o ID não existir")]
        public async Task ById_ShouldReturnFalse_WhenUserDoesntExist()
        {
            // Arrange
            var id = Guid.NewGuid();
            var mockRepo = new Mock<IUserRepository>();

            mockRepo.Setup(repo => repo.FindUserById(id)).ReturnsAsync((User)null!);

            var service = new UserExistService(mockRepo.Object);

            // Act
            var result = await service.ById(id);

            // Assert
            Assert.False(result);
        }

        [Fact(DisplayName = "Retorna TRUE se o usuário com o EMAIL existir")]
        public async Task ByEmail_ShouldReturnTrue_WhenUserExist()
        {
            // Arrange
            var email = new Faker().Internet.Email();
            var user = UserDbMock.Generate();

            var mockRepo = new Mock<IUserRepository>();
            mockRepo.Setup(repo => repo.FindUserByEmail(email))
                .ReturnsAsync(user);

            var service = new UserExistService(mockRepo.Object);

            // Act
            var result = await service.ByEmail(email);

            // Assert
            Assert.True(result);
        }

        [Fact(DisplayName = "Retorna TRUE se o usuário com o ID existir")]
        public async Task ById_ShouldReturnTrue_WhenUserExist()
        {
            // Arrange
            var id = Guid.NewGuid();
            var user = UserDbMock.Generate();

            var mockRepo = new Mock<IUserRepository>();
            mockRepo.Setup(repo => repo.FindUserById(id))
                .ReturnsAsync(user);

            var service = new UserExistService(mockRepo.Object);

            // Act
            var result = await service.ById(id);

            // Assert
            Assert.True(result);
        }
    }
}
