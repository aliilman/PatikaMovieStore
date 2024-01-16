using FluentValidation;
using PatikaMovieStore.Applications.ActorOperations.Commands.DeleteActor;

namespace PatikaMovieStore.Applications.ActorOperations.Commands.DeleteActor
{
  public class DeleteActorCommandValidator : AbstractValidator<DeleteActorCommand>
  {
    public DeleteActorCommandValidator()
    {
      RuleFor(command => command.ActorId).GreaterThan(0);
    } 
  }
}