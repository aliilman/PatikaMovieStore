using AutoMapper;
using FluentAssertions;
using PatikaMovieStore.Applications.DirectorOperations.Commands.CreateDirector;
using PatikaMovieStore.DBOperations;
using PatikaMovieStore.Entities;
using TestSetup;
using Xunit;

namespace PatikaMovieStore.Application.DirectorOperations
{
    public class CreateDirectorCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public CreateDirectorCommandTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

        [Fact]
        public void WhenAlreadyExistDirectorNameIsGiven_InvalidOperationException_ShouldBeReturnError()
        {
            //arrange (hazırlık)
            var Director = new Director { Name = "Eric" ,LastName="baly"};
            _context.Directors.Add(Director);
            _context.SaveChanges();

            CreateDirectorCommand command = new CreateDirectorCommand(_context);
            command.Model = new CreateDirectorModel
            {
                Name = Director.Name,
                LastName= Director.LastName,
            };

            //act && assert (çalıştırma && doğrulama)
            FluentActions
                .Invoking(() => command.Handle()).Should().Throw<InvalidOperationException>();
        }


        [Fact]
        public void WhenValidInputIsGiven_Director_ShouldBeCreated()
        {
            //arrange (hazırlama)
            CreateDirectorCommand command = new CreateDirectorCommand(_context);
            command.Model = new CreateDirectorModel { Name = "ali123", LastName = "ilman"};

            //act (çalıştırma)
            FluentActions
                .Invoking(() => command.Handle()).Invoke();

            //assert (doğrulama)
            var Director = _context.Directors.SingleOrDefault(x => x.Name == command.Model.Name);
            Director.Should().NotBeNull();
            Director.LastName.Should().Be(command.Model.LastName);

        }
    }
}