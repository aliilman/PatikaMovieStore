
using AutoMapper;
using FluentAssertions;
using PatikaMovieStore.Applications.ActorOperations.Commands.UpdateActor;
using PatikaMovieStore.DBOperations;
using TestSetup;
using Xunit;

namespace PatikaMovieStore.Application.ActorOperations
{
    public class UpdateActorCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public UpdateActorCommandTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper= testFixture.Mapper;
        }

        [Fact]
        public void WhenAlreadyExistActorIdIsGiven_InvalidOperationException_ShouldBeReturn()
        {
            // Arrange (Hazırlık)
            UpdateActorCommand command = new UpdateActorCommand(_context);
            command.ActorId = 0;

            // act & asset (Çalıştırma ve Doğrulama)
            FluentActions
                .Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>();

        }

        [Fact]
        public void WhenGivenActorIdinDB_Actor_ShouldBeUpdate()
        {
            UpdateActorCommand command = new UpdateActorCommand(_context);

           UpdateActorModel model = new UpdateActorModel(){Name="WhenGivenBookIdinDB_Book_ShouldBeUpdate", LastName="Rebart"};            
            command.Model = model;
            command.ActorId = 1;

            FluentActions.Invoking(()=> command.Handle()).Invoke();

            var Actor=_context.Actors.SingleOrDefault(Actor=>Actor.Id == command.ActorId);
            Actor.Should().NotBeNull();
            
        }
    }
}