using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PatikaMovieStore.Applications.GenreOperations.Commands.CreateGenre;
using PatikaMovieStore.Applications.GenreOperations.Commands.DeleteGenre;
using PatikaMovieStore.Applications.GenreOperations.Commands.UpdateGenre;
using PatikaMovieStore.Applications.GenreOperations.Queries.GetGenreDetail;
using PatikaMovieStore.Applications.GenreOperations.Queries.GetGenres;
using PatikaMovieStore.DBOperations;

namespace PatikaMovieStore.Controllers
{

  [ApiController]
  [Route("[controller]s")]
  public class GenreController : ControllerBase
  {
     private readonly IMovieStoreDbContext _context; 
     private readonly IMapper _mapper;
    public GenreController(IMovieStoreDbContext context, IMapper mapper)
    {
      _context = context;
      _mapper = mapper;
    }

    [HttpGet]
    public ActionResult GetGenres()
    {
      GetGenresQuery query = new GetGenresQuery(_context, _mapper);
      var obj = query.Handle();
      return Ok(obj);
    }

    [HttpGet("{id}")]
    public ActionResult GetGenreDetail(int id)
    {
      GetGenreDetailQuery query = new GetGenreDetailQuery(_context, _mapper);
      query.GenreId = id;
      GetGenreDetailQueryValidator validator = new GetGenreDetailQueryValidator();
      validator.ValidateAndThrow(query);
      var obj = query.Handle();
      return Ok(obj);
    }

    [HttpPost]
    public IActionResult AddGenre([FromBody] CreateGenreModel newGenre)
    {
      CreateGenreCommand command = new CreateGenreCommand(_context);
      command.Model = newGenre;

      CreateGenreCommandValidator validator = new CreateGenreCommandValidator();
      validator.ValidateAndThrow(command);

      command.Handle();
      return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult UpdateGenre(int id, [FromBody] UpdateGenreModel newGenre)
    {
      UpdateGenreCommand command = new UpdateGenreCommand(_context);      
      command.Model = newGenre;
      command.GenreId = id;

      UpdateGenreCommandValidator validator = new UpdateGenreCommandValidator();
      validator.ValidateAndThrow(command);

      command.Handle();
      return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteGenre(int id)
    {
      DeleteGenreCommand command = new DeleteGenreCommand(_context);
      command.GenreId = id;

      DeleteGenreCommandValidator validator = new DeleteGenreCommandValidator();
      validator.ValidateAndThrow(command);

      command.Handle();
      return Ok();
    }
  }
}