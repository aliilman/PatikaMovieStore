using System;
using AutoMapper;
using FluentAssertions;
using PatikaMovieStore.Applications.MovieOperations.Commands.UpdateMovie;
using PatikaMovieStore.DBOperations;
using PatikaMovieStore.Entities;

using TestSetup;

namespace Application.MovieOperations.Commands.UpdateMovie
{
  public class UpdateMovieCommandTests : IClassFixture<CommonTestFixture>
  {
    private readonly MovieStoreDbContext _context;
    private readonly IMapper _mapper;
    public UpdateMovieCommandTests(CommonTestFixture testFixture)
    {
      _context = testFixture.Context;
      _mapper = testFixture.Mapper;
    }
    [Fact]
    public void WhenInvalidMovieTitleIsGiven_InvalidOperationException_ShouldBeReturn()
    {      
      var Movie = new Movie(){Name = "WhenInvalidMovieTitleIsGiven_InvalidOperationException_ShouldBeReturn", Price = 100, PublishDate = new System.DateTime(1990, 01, 10), GenreId = 1, DirectorId = 1};

      _context.Movies.Add(Movie);
      _context.SaveChanges();

      UpdateMovieCommand command = new UpdateMovieCommand(_context);
      command.Model = new UpdateMovieCommand.UpdateMovieModel(){Name = Movie.Name};

      FluentActions
        .Invoking(()=> command.Handle())
        .Should().Throw<InvalidOperationException>();
    }
  }
}