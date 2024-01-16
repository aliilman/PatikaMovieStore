
using AutoMapper;
using FluentAssertions;
using PatikaMovieStore.Applications.DirectorOperations.Commands.UpdateDirector;
using PatikaMovieStore.DBOperations;
using TestSetup;
using Xunit;

namespace PatikaMovieStore.Application.DirectorOperations
{
    public class UpdateDirectorCommandValidatorTest : IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public UpdateDirectorCommandValidatorTest(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper= testFixture.Mapper;
        }

        [Theory]
        [InlineData(-1, "Lord Of", " ")]
        [InlineData(1, " ", " ")]
        [InlineData(1, "", "ASDF")]
        public void WhenInvalidInputAreGiven_Validator_ShouldBeReturnErrors(int Directorid, string firstname, string lastname)
        {
            //arrange
            UpdateDirectorCommand command = new UpdateDirectorCommand(_context);
            command.Model = new UpdateDirectorModel() { Name = firstname, LastName = lastname };
            command.DirectorId = Directorid;
            //act
            UpdateDirectorCommandValidator validator = new UpdateDirectorCommandValidator();
            var result = validator.Validate(command);

            //assert
            result.Errors.Count.Should().BeGreaterThan(0);

        }

        [InlineData(1, "Lord Of The Rings", "ASDF")]
        [Theory]
        public void WhenValidInputsAreGiven_Validator_ShouldNotBeReturnErrors(int Directorid, string firstname, string lastname)
        {
            UpdateDirectorCommand command = new UpdateDirectorCommand(_context);
            command.Model = new UpdateDirectorModel()
            {
                Name = firstname,
                LastName = lastname
            };
            command.DirectorId = Directorid;

            UpdateDirectorCommandValidator validations = new UpdateDirectorCommandValidator();
            var result = validations.Validate(command);

            result.Errors.Count.Should().Be(0);
        }


    }
}