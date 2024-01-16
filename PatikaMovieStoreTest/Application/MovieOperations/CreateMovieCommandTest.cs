using AutoMapper;
using FluentAssertions;
using PatikaMovieStore.Applications.MovieOperations.Commands.CreateMovie;
using PatikaMovieStore.DBOperations;
using PatikaMovieStore.Entities;

using TestSetup;

using Xunit;


namespace Application.MovieOperations.Commands.CreateMovie
{
  public class CreateMovieCommandTests : IClassFixture<CommonTestFixture>
  {
    private readonly MovieStoreDbContext _context;
    private readonly IMapper _mapper;
    public CreateMovieCommandTests(CommonTestFixture testFixture)
    {
      _context = testFixture.Context;
      _mapper = testFixture.Mapper;
    }
    [Fact]
    public void WhenAlreadyExistMovieNameIsGiven_InvalidOperationException_ShouldBeReturn()
    {
      var Movie = new Movie() { Name = "Test_WhenAlreadyExistMovieTitleIsGiven_InvalidOperationException_ShouldBeReturn", Price = 100, PublishDate = new System.DateTime(1990, 01, 10), GenreId = 1, DirectorId = 1 };

      _context.Movies.Add(Movie);
      _context.SaveChanges();

      CreateMovieCommand command = new CreateMovieCommand(_context, _mapper);
      command.Model = new CreateMovieCommand.CreateMovieModel() { Name = Movie.Name };

      FluentActions
        .Invoking(() => command.Handle())
        .Should().Throw<InvalidOperationException>();
    }

    [Fact]
    public void WhenValidInputsAreGiven_Movie_ShouldBeCreated()
    {
      CreateMovieCommand command = new CreateMovieCommand(_context, _mapper);
      CreateMovieCommand.CreateMovieModel model = new CreateMovieCommand.CreateMovieModel()
      {
        Name = "Hobbit",
        Price = 1000,
        PublishDate = DateTime.Now.Date.AddYears(-10),
        GenreId = 1,
        DirectorId=1,
        Actors = new List<Actor>{
          new Actor { Name = "Haluk", LastName = "Bilginer" },
          new Actor { Name = "Cayci", LastName = "Hüseyin" },
        } 
      };
      command.Model = model;

      FluentActions.Invoking(() => command.Handle()).Invoke();

      var Movie = _context.Movies.SingleOrDefault(Movie => Movie.Name == model.Name);
      Movie.Should().NotBeNull();
      Movie.Price.Should().Be(model.Price);
      Movie.PublishDate.Should().Be(model.PublishDate);
      Movie.GenreId.Should().Be(model.GenreId);
      Movie.DirectorId.Should().Be(model.DirectorId);
      //Movie.Actors.Should().BeSameAs(model.Actors);

    }
  }
}