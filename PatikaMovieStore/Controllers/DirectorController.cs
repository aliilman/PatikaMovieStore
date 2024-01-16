using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PatikaMovieStore.Applications.DirectorOperations.Commands.CreateDirector;
using PatikaMovieStore.Applications.DirectorOperations.Commands.DeleteDirector;
using PatikaMovieStore.Applications.DirectorOperations.Commands.UpdateDirector;
using PatikaMovieStore.Applications.DirectorOperations.Queries.GetDirectorDetail;
using PatikaMovieStore.Applications.DirectorOperations.Queries.GetDirectors;
using PatikaMovieStore.DBOperations;

namespace PatikaMovieStore.Controllers
{

  [ApiController]
  [Route("[controller]s")]
  public class DirectorController : ControllerBase
  {
     private readonly MovieStoreDbContext _context; 
     private readonly IMapper _mapper;
    public DirectorController(MovieStoreDbContext context, IMapper mapper)
    {
      _context = context;
      _mapper = mapper;
    }

    [HttpGet]
    public ActionResult GetDirectors()
    {
      GetDirectorsQuery directors = new GetDirectorsQuery(_context, _mapper);
      var obj = directors.Handle();
      return Ok(obj);
    }

    [HttpGet("{id}")]
    public ActionResult GetDirectorDetail(int id)
    {
      GetDirectorDetailQuery director = new GetDirectorDetailQuery(_context, _mapper);
      director.DirectorId = id;
      GetDirectorDetailQueryValidator validator = new GetDirectorDetailQueryValidator();
      validator.ValidateAndThrow(director);
      var obj = director.Handle();
      return Ok(obj);
    }

    [HttpPost]
    public IActionResult AddDirector([FromBody] CreateDirectorModel newDirector)
    {
      CreateDirectorCommand command = new CreateDirectorCommand(_context);
      command.Model = newDirector;

      CreateDirectorCommandValidator validator = new CreateDirectorCommandValidator();
      validator.ValidateAndThrow(command);

      command.Handle();
      return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult UpdateDirector(int id, [FromBody] UpdateDirectorModel newDirector)
    {
      UpdateDirectorCommand command = new UpdateDirectorCommand(_context);      
      command.Model = newDirector;
      command.DirectorId = id;

      UpdateDirectorCommandValidator validator = new UpdateDirectorCommandValidator();
      validator.ValidateAndThrow(command);

      command.Handle();
      return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteDirector(int id)
    {
      DeleteDirectorCommand command = new DeleteDirectorCommand(_context);
      command.DirectorId = id;

      DeleteDirectorCommandValidator validator = new DeleteDirectorCommandValidator();
      validator.ValidateAndThrow(command);

      command.Handle();
      return Ok();
    }
  }
}