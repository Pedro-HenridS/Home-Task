using Bogus;
using domain.Entities;

namespace application.test.Utilities.UserMock
{
    public class ListFriendDbMock
    {
        public static List<Friends> Generate(int quantidade = 5)
        {
            var faker = new Faker<Friends>()
            .RuleFor(u => u.Id, f => Guid.NewGuid())
            .RuleFor(u => u.User1_Id, f => Guid.NewGuid())
            .RuleFor(u => u.User2_Id, f => Guid.NewGuid());

            return faker.Generate(quantidade);
        }
    }
}
