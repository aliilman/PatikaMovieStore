
using FluentAssertions;
using PatikaMovieStore.Applications.DirectorOperations.Commands.CreateDirector;
using TestSetup;


namespace PatikaMovieStore.Application.DirectorOperations
{
    public class CreateDirectorCommandValidatorTests : IClassFixture<CommonTestFixture>
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
            CreateDirectorCommand command = new CreateDirectorCommand(null);
            command.Model = new CreateDirectorModel(){Name = firstname, LastName = lastname};
            
            //act
            CreateDirectorCommandValidator validator = new CreateDirectorCommandValidator();
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
            CreateDirectorCommand command = new CreateDirectorCommand(null);
            command.Model = new CreateDirectorModel(){Name = firstname,LastName = lastname};
            
            //act
            CreateDirectorCommandValidator validator = new CreateDirectorCommandValidator();
            var result = validator.Validate(command);

            //assert
            result.Errors.Count.Should().Be(0);
           
        } 
    }
}