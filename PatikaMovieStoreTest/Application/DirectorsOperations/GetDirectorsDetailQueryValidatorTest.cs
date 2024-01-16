
using FluentAssertions;
using PatikaMovieStore.Applications.DirectorOperations.Queries.GetDirectorDetail;
using TestSetup;
using Xunit;

namespace PatikaMovieStore.Application.DirectorOperations
{
     public class GetDirectorDetailQueryValidatorTests:IClassFixture<CommonTestFixture>
    {

        [InlineData(-1)]
        [InlineData(0)]
        [InlineData(-10)]
        [Theory]
        public void WhenInvalidDirectoridIsGiven_Validator_ShouldBeReturnErrors(int Directorid)
        {
            GetDirectorDetailQuery query = new GetDirectorDetailQuery(null,null);
            query.DirectorId=Directorid;

            GetDirectorDetailQueryValidator validator = new GetDirectorDetailQueryValidator();
            var result = validator.Validate(query);

            result.Errors.Count.Should().BeGreaterThan(0);
        }


        [InlineData(1)]
        [InlineData(100)]
        [Theory]
        public void WhenInvalidDirectoridIsGiven_Validator_ShouldNotBeReturnErrors(int Directorid)
        {
            GetDirectorDetailQuery query = new GetDirectorDetailQuery(null,null);
            query.DirectorId=Directorid;

            GetDirectorDetailQueryValidator validator = new GetDirectorDetailQueryValidator();
            var result = validator.Validate(query);

            result.Errors.Count.Should().Be(0);
        }


    }
}