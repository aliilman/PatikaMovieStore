
using AutoMapper;
using FluentAssertions;
using PatikaMovieStore.Applications.UserOperations.Commands.UpdateUser;
using PatikaMovieStore.DBOperations;
using TestSetup;
using Xunit;

namespace PatikaMovieStore.Application.UserOperations
{
    public class UpdateUserCommandValidatorTest : IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public UpdateUserCommandValidatorTest(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper= testFixture.Mapper;
        }

        [Theory]
        [InlineData(-1, "Lord Of", " ")]
        [InlineData(1, " ", " ")]
        [InlineData(1, "", "ASDF")]
        public void WhenInvalidInputAreGiven_Validator_ShouldBeReturnErrors(int Userid, string firstname, string lastname)
        {
            //arrange
            UpdateUserCommand command = new UpdateUserCommand(_context);
            command.Model = new UpdateUserModel() { Name = firstname, LastName = lastname };
            command.UserId = Userid;
            //act
            UpdateUserCommandValidator validator = new UpdateUserCommandValidator();
            var result = validator.Validate(command);

            //assert
            result.Errors.Count.Should().BeGreaterThan(0);

        }

        [InlineData(1, "Lord Of The Rings", "ASDFs","elmaila@gmail.com","passropwd")]
        [Theory]
        public void WhenValidInputsAreGiven_Validator_ShouldNotBeReturnErrors(int Userid, string firstname, string lastname,string email,string password)
        {
            UpdateUserCommand command = new UpdateUserCommand(_context);
            command.Model = new UpdateUserModel()
            {
                Name = firstname,
                LastName = lastname,
                Email = email,
                Password= password
            };
            command.UserId = Userid;

            UpdateUserCommandValidator validations = new UpdateUserCommandValidator();
            var result = validations.Validate(command);

            result.Errors.Count.Should().Be(0);
        }


    }
}