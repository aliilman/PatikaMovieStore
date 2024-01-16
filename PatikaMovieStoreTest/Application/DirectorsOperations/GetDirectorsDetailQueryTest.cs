
using AutoMapper;
using FluentAssertions;
using PatikaMovieStore.Applications.DirectorOperations.Queries.GetDirectorDetail;
using PatikaMovieStore.DBOperations;
using TestSetup;
using Xunit;

namespace PatikaMovieStore.Application.DirectorOperations
{
      public class GetDirectorDetailQueryTests:IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDbContext _context;
        private readonly IMapper  _mapper;

        public GetDirectorDetailQueryTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

        [Fact]
        public void WhenGivenDirectorIdIsNotinDB_InvalidOperationException_ShouldBeReturn()
        {
            GetDirectorDetailQuery command = new GetDirectorDetailQuery(_context,_mapper);
            command.DirectorId=0;

            FluentActions.Invoking(() => command.Handle())
            .Should().Throw<InvalidOperationException>();
        }

        [Fact]
        public void WhenGivenDirectorIdIsinDB_InvalidOperationException_ShouldBeReturn()
        {
            GetDirectorDetailQuery command = new GetDirectorDetailQuery(_context,_mapper);
            command.DirectorId=1;
            

            FluentActions.Invoking(()=> command.Handle()).Invoke();

            var Director=_context.Directors.SingleOrDefault(Director=>Director.Id == command.DirectorId);
            Director.Should().NotBeNull();
        }
    }
}