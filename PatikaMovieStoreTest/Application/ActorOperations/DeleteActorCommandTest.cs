
using FluentAssertions;
using PatikaMovieStore.Applications.ActorOperations.Commands.DeleteActor;
using PatikaMovieStore.DBOperations;
using PatikaMovieStore.Entities;
using TestSetup;
using Xunit;

namespace PatikaMovieStore.Application.ActorOperations
{
     public class DeleteActorCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDbContext _context;
        public DeleteActorCommandTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
        }
        [Fact]
        public void WhenGivenActorIdIsNotinDB_InvalidOperationException_ShouldBeReturn()
        {
            DeleteActorCommand command = new DeleteActorCommand(_context);
            command.ActorId = 0;

            FluentActions.Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>();
        }


        [Fact]
        public void WhenGivenBookIdNotEqualActorId_InvalidOperationException_ShouldBeReturn()
        {
            
            DeleteActorCommand command = new DeleteActorCommand(_context);
            command.ActorId = 1;

           FluentActions
                .Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>();
          }


        [Fact]
        public void WhenValidInputsAreGiven_Actor_ShouldBeDeleted()
        {
            //arrange
           var Actor = new Actor() {Name="Franki", LastName="Rebart"};
           _context.Add(Actor);
           _context.SaveChanges();

           DeleteActorCommand command = new DeleteActorCommand(_context);
           command.ActorId = Actor.Id;

            //act
            FluentActions.Invoking(() => command.Handle()).Invoke();

            //assert
            Actor = _context.Actors.SingleOrDefault(x=> x.Id == Actor.Id);
            Actor.Should().BeNull();

        }
    }
}