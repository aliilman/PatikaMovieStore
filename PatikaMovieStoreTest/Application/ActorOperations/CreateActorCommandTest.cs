using AutoMapper;
using FluentAssertions;
using PatikaMovieStore.Applications.ActorOperations.Commands.CreateActor;
using PatikaMovieStore.DBOperations;
using PatikaMovieStore.Entities;
using TestSetup;
using Xunit;

namespace PatikaMovieStore.Application.ActorOperations
{
    public class CreateActorCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public CreateActorCommandTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

        [Fact]
        public void WhenAlreadyExistActorNameIsGiven_InvalidOperationException_ShouldBeReturnError()
        {
            //arrange (hazırlık)
            var Actor = new Actor { Name = "Eric" ,LastName="Bali"};
            _context.Actors.Add(Actor);
            _context.SaveChanges();

            CreateActorCommand command = new CreateActorCommand(_context);
            command.Model = new CreateActorModel
            {
                Name = Actor.Name,
                LastName = Actor.LastName,
            };

            //act && assert (çalıştırma && doğrulama)
            FluentActions
                .Invoking(() => command.Handle()).Should().Throw<InvalidOperationException>();
        }


        [Fact]
        public void WhenValidInputIsGiven_Actor_ShouldBeCreated()
        {
            //arrange (hazırlama)
            CreateActorCommand command = new CreateActorCommand(_context);
            command.Model = new CreateActorModel { Name = "ali123", LastName = "ilman"};

            //act (çalıştırma)
            FluentActions
                .Invoking(() => command.Handle()).Invoke();

            //assert (doğrulama)
            var Actor = _context.Actors.SingleOrDefault(x => x.Name == command.Model.Name);
            Actor.Should().NotBeNull();
            Actor.LastName.Should().Be(command.Model.LastName);

        }
    }
}