
using AutoMapper;
using FluentAssertions;
using PatikaMovieStore.Applications.ActorOperations.Commands.UpdateActor;
using PatikaMovieStore.DBOperations;
using TestSetup;
using Xunit;

namespace PatikaMovieStore.Application.ActorOperations
{
    public class UpdateActorCommandValidatorTest : IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public UpdateActorCommandValidatorTest(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper= testFixture.Mapper;
        }

        [Theory]
        [InlineData(-1, "Lord Of", " ")]
        [InlineData(1, " ", " ")]
        [InlineData(1, "", "ASDF")]
        public void WhenInvalidInputAreGiven_Validator_ShouldBeReturnErrors(int Actorid, string firstname, string lastname)
        {
            //arrange
            UpdateActorCommand command = new UpdateActorCommand(_context);
            command.Model = new UpdateActorModel() { Name = firstname, LastName = lastname };
            command.ActorId = Actorid;
            //act
            UpdateActorCommandValidator validator = new UpdateActorCommandValidator();
            var result = validator.Validate(command);

            //assert
            result.Errors.Count.Should().BeGreaterThan(0);

        }

        [InlineData(1, "Lord Of The Rings", "ASDF")]
        [Theory]
        public void WhenValidInputsAreGiven_Validator_ShouldNotBeReturnErrors(int Actorid, string firstname, string lastname)
        {
            UpdateActorCommand command = new UpdateActorCommand(_context);
            command.Model = new UpdateActorModel()
            {
                Name = firstname,
                LastName = lastname
            };
            command.ActorId = Actorid;

            UpdateActorCommandValidator validations = new UpdateActorCommandValidator();
            var result = validations.Validate(command);

            result.Errors.Count.Should().Be(0);
        }


    }
}