
using AutoMapper;
using FluentAssertions;
using PatikaMovieStore.Applications.UserOperations.Commands.UpdateUser;
using PatikaMovieStore.DBOperations;
using TestSetup;
using Xunit;

namespace PatikaMovieStore.Application.UserOperations
{
    public class UpdateUserCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public UpdateUserCommandTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper= testFixture.Mapper;
        }

        [Fact]
        public void WhenAlreadyExistUserIdIsGiven_InvalidOperationException_ShouldBeReturn()
        {
            // Arrange (Hazırlık)
            UpdateUserCommand command = new UpdateUserCommand(_context);
            command.UserId = 0;

            // act & asset (Çalıştırma ve Doğrulama)
            FluentActions
                .Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>();

        }

        [Fact]
        public void WhenGivenUserIdinDB_User_ShouldBeUpdate()
        {
            UpdateUserCommand command = new UpdateUserCommand(_context);

           UpdateUserModel model = new UpdateUserModel(){
               Name="WhenGivenBookIdinDB_Book_ShouldBeUpdate",
               LastName="Rebart",
               Email = "frank@mail.com",
               Password = "asdas",
               FavoriteGenreIDList =new List<int> { 2},
               PurchasedMoviesIDList = new List<int> { 1 }
           };            
            command.Model = model;
            command.UserId = 1;

            FluentActions.Invoking(()=> command.Handle()).Invoke();

            var User=_context.Users.SingleOrDefault(User=>User.Id == command.UserId);
            User.Should().NotBeNull();
            
        }
    }
}