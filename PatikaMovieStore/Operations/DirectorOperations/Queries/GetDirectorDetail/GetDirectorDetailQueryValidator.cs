using FluentValidation;

namespace PatikaMovieStore.Applications.DirectorOperations.Queries.GetDirectorDetail
{
  public class GetDirectorDetailQueryValidator : AbstractValidator<GetDirectorDetailQuery>
  {
    public GetDirectorDetailQueryValidator()
    {
      RuleFor(query => query.DirectorId).GreaterThan(0);
    } 
  }
}