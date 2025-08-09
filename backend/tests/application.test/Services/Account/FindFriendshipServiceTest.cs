using application.Services.Account;
using application.test.Utilities.UserMock;
using domain.Entities;
using domain.Interfaces.Friends_Interfaces;
using Exception.Friend;
using Moq;

namespace application.test.Services.Account
{
    public class FindFriendshipServiceTest
    {
        [Fact(DisplayName = "AllFriends deve lançar uma exceção quando nenhuma amigo for encontrado")]
        public async Task AllFriends_ShouldThrowError_WhenFriendsDoesntExist()
        {
            // Arrange
            var id = Guid.NewGuid();

            var mockRepo = new Mock<IFriendsRepositories>();
            mockRepo.Setup(repo => repo.AllFriends(id))
                .ReturnsAsync((List<Friends>)null!);

            var service = new FindFriendshipService(mockRepo.Object);

            // Assert com Assert
            await Assert.ThrowsAsync<FriendshipException>(() =>  service.AllFriends(id));    
        }

        [Fact(DisplayName = "AllFriends deve retornar uma lista de amigos")]
        public async Task AllFriends_ShouldReturnFriendsList_WhenFriendsDoesntExist()
        {
            // Arrange
            var id = Guid.NewGuid();
            var listFriends = ListFriendDbMock.Generate();

            var mockRepo = new Mock<IFriendsRepositories>();
            mockRepo.Setup(repo => repo.AllFriends(id))
                .ReturnsAsync(listFriends);

            var service = new FindFriendshipService(mockRepo.Object);

            // Assert com Assert
            Assert.IsType<List<Friends>>(await service.AllFriends(id));
        }
    }
}
