using FluentValidation;

namespace PatikaMovieStore.Applications.DirectorOperations.Commands.DeleteDirector
{
  public class DeleteDirectorCommandValidator : AbstractValidator<DeleteDirectorCommand>
  {
    public DeleteDirectorCommandValidator()
    {
      RuleFor(command => command.DirectorId).GreaterThan(0);
    } 
  }
}