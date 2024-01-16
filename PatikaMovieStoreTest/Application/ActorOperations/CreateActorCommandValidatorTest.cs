
using FluentAssertions;
using PatikaMovieStore.Applications.ActorOperations.Commands.CreateActor;
using TestSetup;


namespace PatikaMovieStore.Application.ActorOperations
{
    public class CreateActorCommandValidatorTests : IClassFixture<CommonTestFixture>
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
            CreateActorCommand command = new CreateActorCommand(null);
            command.Model = new CreateActorModel(){Name = firstname, LastName = lastname};
            
            //act
            CreateActorCommandValidator validator = new CreateActorCommandValidator();
            var result = validator.Validate(command);

            //assert
            result.Errors.Count.Should().BeGreaterThan(0);
           
        }


        [Theory]
        [InlineData("asdf ", " asdf")]
        [InlineData("asdf", "asdf" )]
        [InlineData("as  ", "sa  " )]
        [InlineData(" as ", " a  " )]
        [InlineData("asdadasdasd", "asdasdasdasdas" )]
        [InlineData(" aaa", "saa " )]
        public void WhenValidInputAreGiven_Validator_ShouldBeReturnErrors(string firstname, string lastname)
        {
            //arrange
            CreateActorCommand command = new CreateActorCommand(null);
            command.Model = new CreateActorModel(){Name = firstname,LastName = lastname};
            
            //act
            CreateActorCommandValidator validator = new CreateActorCommandValidator();
            var result = validator.Validate(command);

            //assert
            result.Errors.Count.Should().Be(0);
           
        } 
    }
}