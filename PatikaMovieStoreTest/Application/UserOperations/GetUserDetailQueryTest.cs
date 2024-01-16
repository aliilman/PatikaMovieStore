
using AutoMapper;
using FluentAssertions;
using PatikaMovieStore.Applications.UserOperations.Queries.GetUserDetail;
using PatikaMovieStore.DBOperations;
using TestSetup;
using Xunit;

namespace PatikaMovieStore.Application.UserOperations
{
      public class GetUserDetailQueryTests:IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDbContext _context;
        private readonly IMapper  _mapper;

        public GetUserDetailQueryTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

        [Fact]
        public void WhenGivenUserIdIsNotinDB_InvalidOperationException_ShouldBeReturn()
        {
            GetUserDetailQuery command = new GetUserDetailQuery(_context,_mapper);
            command.UserId=0;

            FluentActions.Invoking(() => command.Handle())
            .Should().Throw<InvalidOperationException>();
        }

        [Fact]
        public void WhenGivenUserIdIsinDB_InvalidOperationException_ShouldBeReturn()
        {
            GetUserDetailQuery command = new GetUserDetailQuery(_context,_mapper);
            command.UserId=1;
            

            FluentActions.Invoking(()=> command.Handle()).Invoke();

            var User=_context.Users.SingleOrDefault(User=>User.Id == command.UserId);
            User.Should().NotBeNull();
        }
    }
}