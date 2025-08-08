using communication.Requests.DTO.UsersDTO;
using Bogus;

namespace CommonTestUtilities.Requests
{
    public class RequestRegisterUserBuilder
    {

        public static RegisterDtoRequest Build() 
        {
            var password = new Faker().Internet.Password();

            var request = new Faker<RegisterDtoRequest>()
                .RuleFor(r => r.UserName, faker => faker.Internet.UserName())
                .RuleFor(r => r.Email, faker => faker.Internet.Email())
                .RuleFor(r => r.Password, faker => password)
                .RuleFor(r => r.ConfirmedPassword, (faker, u) => password);

            return request;
        }
        
    }
}
