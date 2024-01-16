using FluentValidation;

namespace PatikaMovieStore.Applications.OrderOperations.Queries.GetOrderDetail
{
  public class GetOrderDetailQueryValidator : AbstractValidator<GetOrderDetailQuery>
  {
    public GetOrderDetailQueryValidator()
    {
      RuleFor(command => command.OrderId).GreaterThan(0);
    }
  }
}