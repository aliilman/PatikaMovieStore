using AutoMapper;
using FluentAssertions;
using PatikaMovieStore.Applications.MovieOperations.Queries.GetMovieDetail;
using PatikaMovieStore.DBOperations;
using TestSetup;
using Xunit;

namespace PatikaMovieStoreTest.Application.MovieOperations
{
    public class GetMovieDetailQueryTests : IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public GetMovieDetailQueryTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

        [Fact]
        public void WhenGivenMovieIdIsNotinDB_InvalidOperationException_ShouldBeReturn()
        {
            GetMovieDetailQuery command = new GetMovieDetailQuery(_context, _mapper);
            command.MovieId = 0;

            FluentActions.Invoking(() => command.Handle())
            .Should().Throw<InvalidOperationException>();
        }

        //[Fact]
        //public void WhenGivenMovieIdIsinDB_InvalidOperationException_ShouldBeReturn()
        //{
        //    GetMovieDetailQuery command = new GetMovieDetailQuery(_context,_mapper);
        //    command.MovieId=1;


        //    FluentActions.Invoking(()=> command.Handle()).Invoke();

        //    var Movie=_context.Movies.SingleOrDefault(Movie=>Movie.Id == command.MovieId);
        //    Movie.Should().NotBeNull();
        //}
    }
}