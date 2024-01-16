
using AutoMapper;
using FluentAssertions;
using PatikaMovieStore.Applications.ActorOperations.Queries.GetActorDetail;
using PatikaMovieStore.DBOperations;
using TestSetup;
using Xunit;

namespace PatikaMovieStore.Application.ActorOperations
{
      public class GetActorDetailQueryTests:IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDbContext _context;
        private readonly IMapper  _mapper;

        public GetActorDetailQueryTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

        [Fact]
        public void WhenGivenActorIdIsNotinDB_InvalidOperationException_ShouldBeReturn()
        {
            GetActorDetailQuery command = new GetActorDetailQuery(_context,_mapper);
            command.ActorId=0;

            FluentActions.Invoking(() => command.Handle())
            .Should().Throw<InvalidOperationException>();
        }

        [Fact]
        public void WhenGivenActorIdIsinDB_InvalidOperationException_ShouldBeReturn()
        {
            GetActorDetailQuery command = new GetActorDetailQuery(_context,_mapper);
            command.ActorId=1;
            

            FluentActions.Invoking(()=> command.Handle()).Invoke();

            var Actor=_context.Actors.SingleOrDefault(Actor=>Actor.Id == command.ActorId);
            Actor.Should().NotBeNull();
        }
    }
}