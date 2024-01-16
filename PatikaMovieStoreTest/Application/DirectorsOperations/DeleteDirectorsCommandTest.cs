
using FluentAssertions;
using PatikaMovieStore.Applications.DirectorOperations.Commands.DeleteDirector;
using PatikaMovieStore.DBOperations;
using PatikaMovieStore.Entities;
using TestSetup;
using Xunit;

namespace PatikaMovieStore.Application.DirectorOperations
{
     public class DeleteDirectorCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDbContext _context;
        public DeleteDirectorCommandTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
        }
        [Fact]
        public void WhenGivenDirectorIdIsNotinDB_InvalidOperationException_ShouldBeReturn()
        {
            DeleteDirectorCommand command = new DeleteDirectorCommand(_context);
            command.DirectorId = 0;

            FluentActions.Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>();
        }


        [Fact]
        public void WhenGivenBookIdNotEqualDirectorId_InvalidOperationException_ShouldBeReturn()
        {
            
            DeleteDirectorCommand command = new DeleteDirectorCommand(_context);
            command.DirectorId = 1;

           FluentActions
                .Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>();
          }


        [Fact]
        public void WhenValidInputsAreGiven_Director_ShouldBeDeletted()
        {
            //arrange
           var Director = new Director() {Name="Frank", LastName="Rebart"};
           _context.Add(Director);
           _context.SaveChanges();

           DeleteDirectorCommand command = new DeleteDirectorCommand(_context);
           command.DirectorId = Director.Id;

            //act
            FluentActions.Invoking(() => command.Handle()).Invoke();

            //assert
            Director = _context.Directors.SingleOrDefault(x=> x.Id == Director.Id);
            Director.Should().BeNull();

        }
    }
}