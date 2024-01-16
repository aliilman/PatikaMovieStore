
using FluentAssertions;
using PatikaMovieStore.Applications.ActorOperations.Queries.GetActorDetail;
using TestSetup;
using Xunit;

namespace PatikaMovieStore.Application.ActorOperations
{
     public class GetActorDetailQueryValidatorTests:IClassFixture<CommonTestFixture>
    {

        [InlineData(-1)]
        [InlineData(0)]
        [InlineData(-10)]
        [Theory]
        public void WhenInvalidActoridIsGiven_Validator_ShouldBeReturnErrors(int Actorid)
        {
            GetActorDetailQuery query = new GetActorDetailQuery(null,null);
            query.ActorId=Actorid;

            GetActorDetailQueryValidator validator = new GetActorDetailQueryValidator();
            var result = validator.Validate(query);

            result.Errors.Count.Should().BeGreaterThan(0);
        }


        [InlineData(1)]
        [InlineData(100)]
        [Theory]
        public void WhenInvalidActoridIsGiven_Validator_ShouldNotBeReturnErrors(int Actorid)
        {
            GetActorDetailQuery query = new GetActorDetailQuery(null,null);
            query.ActorId=Actorid;

            GetActorDetailQueryValidator validator = new GetActorDetailQueryValidator();
            var result = validator.Validate(query);

            result.Errors.Count.Should().Be(0);
        }


    }
}