using System;
using System.Linq;
using FluentAssertions;
using PatikaMovieStore.Applications.MovieOperations.Commands.DeleteMovie;
using PatikaMovieStore.DBOperations;

using TestSetup;

using Xunit;

namespace Application.MovieOperations.Commands.DeleteMovie
{
  public class DeleteMovieCommandTests : IClassFixture<CommonTestFixture>
  {
    private readonly MovieStoreDbContext _context;
    public DeleteMovieCommandTests(CommonTestFixture testFixture)
    {
      _context = testFixture.Context;
    }
    [Fact]
    public void WhenGivenMovieIdDoesNotFound_InvalidOperationException_ShouldBeReturnError()
    {
      DeleteMovieCommand command = new DeleteMovieCommand(_context);
      command.MovieId = 9999;

      DeleteMovieCommandValidator validator = new DeleteMovieCommandValidator();
      var result = validator.Validate(command);

      FluentActions
        .Invoking(()=> command.Handle())
        .Should().Throw<InvalidOperationException>();
    }

    [Fact]
    public void WhenValideMovieIdGiven_InvalidOperationException_ShouldBeReturnOk()
    {
      DeleteMovieCommand command = new DeleteMovieCommand(_context);
      command.MovieId = 1;

      DeleteMovieCommandValidator validator = new DeleteMovieCommandValidator();
      var result = validator.Validate(command);

      FluentActions.Invoking(() => command.Handle()).Invoke();

      var Movie = _context.Movies.SingleOrDefault(Movie => Movie.Id == command.MovieId);

      Movie.Should().BeNull();
    }
  }
}