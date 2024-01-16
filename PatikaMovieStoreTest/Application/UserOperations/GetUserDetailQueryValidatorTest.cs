
using FluentAssertions;
using PatikaMovieStore.Applications.UserOperations.Queries.GetUserDetail;
using TestSetup;
using Xunit;

namespace PatikaMovieStore.Application.UserOperations
{
     public class GetUserDetailQueryValidatorTests:IClassFixture<CommonTestFixture>
    {

        [InlineData(-1)]
        [InlineData(0)]
        [InlineData(-10)]
        [Theory]
        public void WhenInvalidUseridIsGiven_Validator_ShouldBeReturnErrors(int Userid)
        {
            GetUserDetailQuery query = new GetUserDetailQuery(null,null);
            query.UserId=Userid;

            GetUserDetailQueryValidator validator = new GetUserDetailQueryValidator();
            var result = validator.Validate(query);

            result.Errors.Count.Should().BeGreaterThan(0);
        }


        [InlineData(1)]
        [InlineData(100)]
        [Theory]
        public void WhenInvalidUseridIsGiven_Validator_ShouldNotBeReturnErrors(int Userid)
        {
            GetUserDetailQuery query = new GetUserDetailQuery(null,null);
            query.UserId=Userid;

            GetUserDetailQueryValidator validator = new GetUserDetailQueryValidator();
            var result = validator.Validate(query);

            result.Errors.Count.Should().Be(0);
        }


    }
}