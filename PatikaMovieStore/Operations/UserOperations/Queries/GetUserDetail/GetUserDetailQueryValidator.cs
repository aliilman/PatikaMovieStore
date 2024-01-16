using FluentValidation;

namespace PatikaMovieStore.Applications.UserOperations.Queries.GetUserDetail
{
  public class GetUserDetailQueryValidator : AbstractValidator<GetUserDetailQuery>
  {
    public GetUserDetailQueryValidator()
    {
      RuleFor(query => query.UserId).GreaterThan(0);
    } 
  }
}