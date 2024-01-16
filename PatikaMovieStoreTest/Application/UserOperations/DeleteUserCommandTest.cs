
using FluentAssertions;
using PatikaMovieStore.Applications.UserOperations.Commands.DeleteUser;
using PatikaMovieStore.DBOperations;
using PatikaMovieStore.Entities;
using TestSetup;
using Xunit;

namespace PatikaMovieStore.Application.UserOperations
{
     public class DeleteUserCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDbContext _context;
        public DeleteUserCommandTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
        }
        [Fact]
        public void WhenGivenUserIdIsNotinDB_InvalidOperationException_ShouldBeReturn()
        {
            DeleteUserCommand command = new DeleteUserCommand(_context);
            command.UserId = 0;

            FluentActions.Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>();
        }


        [Fact]
        public void WhenGivenBookIdNotEqualUserId_InvalidOperationException_ShouldBeReturn()
        {
            
            DeleteUserCommand command = new DeleteUserCommand(_context);
            command.UserId = 50;

           FluentActions
                .Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>();
          }


        [Fact]
        public void WhenValidInputsAreGiven_User_ShouldBeCreated()
        {
            //arrange
           var User = new User() {Name="Frank1", LastName="Rebart",Email="frank@mail.com",Password="asdas"};
           _context.Add(User);
           _context.SaveChanges();

           DeleteUserCommand command = new DeleteUserCommand(_context);
           command.UserId = User.Id;

            //act
            FluentActions.Invoking(() => command.Handle()).Invoke();

            //assert
            User = _context.Users.SingleOrDefault(x=> x.Id == User.Id);
            User.Should().BeNull();

        }
    }
}