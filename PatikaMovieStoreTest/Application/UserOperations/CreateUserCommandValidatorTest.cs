
using FluentAssertions;
using PatikaMovieStore.Applications.UserOperations.Commands.CreateUser;
using TestSetup;


namespace PatikaMovieStore.Application.UserOperations
{
    public class CreateUserCommandValidatorTests : IClassFixture<CommonTestFixture>
    {
       
        [Theory]
        [InlineData(" ", " ")]
        [InlineData(" ", "aaa" )]
        [InlineData("aaa", " " )]
        [InlineData("as", "a" )]
        [InlineData("a", "sa" )]

        public void WhenInvalidInputAreGiven_Validator_ShouldBeReturnErrors(string firstname, string lastname)
        {
            //arrange
            CreateUserCommand command = new CreateUserCommand(null,null);
            command.Model = new CreateUserModel(){Name = firstname, LastName = lastname};
            
            //act
            CreateUserCommandValidator validator = new CreateUserCommandValidator();
            var result = validator.Validate(command);

            //assert
            result.Errors.Count.Should().BeGreaterThan(0);
           
        }

        [Fact]
        public void WhenDateTimeEqualNowIsGiven_Validator_ShouldBeReturnError()
        {
            CreateUserCommand command = new CreateUserCommand(null,null);
            command.Model = new CreateUserModel()
            {
                Name = "Frank",
                LastName = "Tolkien"
            };

            CreateUserCommandValidator validator = new CreateUserCommandValidator();
            var result = validator.Validate(command);

            result.Errors.Count.Should().BeGreaterThan(0);
            
        }

        [Theory]
        [InlineData("ali ", "ilman","aliiilman@gmail.com","ali123")]
        public void WhenValidInputAreGiven_Validator_ShouldNotBeReturnErrors(string firstname, string lastname, string email,string password)
        {
            //arrange
            CreateUserCommand command = new CreateUserCommand(null,null);
            command.Model = new CreateUserModel(){Name = firstname,LastName = lastname,Email=email,Password=password};
            
            //act
            CreateUserCommandValidator validator = new CreateUserCommandValidator();
            var result = validator.Validate(command);

            //assert
            result.Errors.Count.Should().Be(0);
           
        } 
    }
}