using Bogus;
using domain.Entities;

namespace application.test.Utilities.UserMock
{
    public class UserDbMock
    {

        public static User Generate()
        {
            return new Faker<User>()
            .RuleFor(u => u.Id, f => Guid.NewGuid())
            .RuleFor(u => u.Username, f => f.Internet.UserName())
            .RuleFor(u => u.Email, f => f.Internet.Email())
            .RuleFor(u => u.Password, f => f.Random.Hash())
            .Generate();
        }
    }
}
