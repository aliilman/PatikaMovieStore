
using AutoMapper;
using FluentAssertions;
using PatikaMovieStore.Applications.DirectorOperations.Commands.UpdateDirector;
using PatikaMovieStore.DBOperations;
using TestSetup;
using Xunit;

namespace PatikaMovieStore.Application.DirectorOperations
{
    public class UpdateDirectorCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public UpdateDirectorCommandTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper= testFixture.Mapper;
        }

        [Fact]
        public void WhenAlreadyExistDirectorIdIsGiven_InvalidOperationException_ShouldBeReturn()
        {
            // Arrange (Hazırlık)
            UpdateDirectorCommand command = new UpdateDirectorCommand(_context);
            command.DirectorId = 0;

            // act & asset (Çalıştırma ve Doğrulama)
            FluentActions
                .Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>();

        }

        [Fact]
        public void WhenGivenDirectorIdinDB_Director_ShouldBeUpdate()
        {
            UpdateDirectorCommand command = new UpdateDirectorCommand(_context);

           UpdateDirectorModel model = new UpdateDirectorModel(){Name="WhenGivenBookIdinDB_Book_ShouldBeUpdate", LastName="Rebart"};            
            command.Model = model;
            command.DirectorId = 1;

            FluentActions.Invoking(()=> command.Handle()).Invoke();

            var Director=_context.Directors.SingleOrDefault(Director=>Director.Id == command.DirectorId);
            Director.Should().NotBeNull();
            
        }
    }
}