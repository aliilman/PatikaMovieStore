using AutoMapper;
using FluentAssertions;
using PatikaMovieStore.Applications.UserOperations.Commands.CreateUser;
using PatikaMovieStore.DBOperations;
using PatikaMovieStore.Entities;
using TestSetup;
using Xunit;

namespace PatikaMovieStore.Application.UserOperations
{
    public class CreateUserCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public CreateUserCommandTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

        [Fact]
        public void WhenAlreadyExistUserNameIsGiven_InvalidOperationException_ShouldBeReturnError()
        {
            //arrange (hazırlık)
            var User = new User
            {
                Email = "aliilman@gmail.com",
                Password = "ali123",
                Name = "ali",
                LastName = " ",
               
            };
            _context.Users.Add(User);
            _context.SaveChanges();

            CreateUserCommand command = new CreateUserCommand(_context,_mapper);
            command.Model = new CreateUserModel
            {
                Name = User.Name,
                Email=User.Email,
                Password=User.Password,
                LastName=User.LastName,
            };

            //act && assert (çalıştırma && doğrulama)
            FluentActions
                .Invoking(() => command.Handle()).Should().Throw<InvalidOperationException>();
        }


        [Fact]
        public void WhenValidInputIsGiven_User_ShouldBeCreated()
        {
            //arrange (hazırlama)
            CreateUserCommand command = new CreateUserCommand(_context,_mapper);
            command.Model = new CreateUserModel
            {
                Email ="aliilman@gmail.com",
                Password="ali123",
                Name= "ali",
                LastName =" ",
                FavoriteGenres = null,
                PurcgasedMovies= null
            };

            //act (çalıştırma)
            FluentActions
                .Invoking(() => command.Handle()).Invoke();

            //assert (doğrulama)
            var User = _context.Users.SingleOrDefault(x => x.Email == command.Model.Email);
            User.Should().NotBeNull();
            User.Name.Should().Be(command.Model.Name);

        }
    }
}