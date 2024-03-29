using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using PatikaMovieStore.DBOperations;

namespace PatikaMovieStore.Applications.GenreOperations.Queries.GetGenres
{
  public class GetGenresQuery
  {
    public readonly IMovieStoreDbContext _context;
    public readonly IMapper _mapper;
    public GetGenresQuery(IMovieStoreDbContext context, IMapper mapper)
    {
      _context = context;
      _mapper = mapper;
    }
    public List<GenresViewModel> Handle()
    {
      var genres = _context.Genres.Where(x => x.IsActive).OrderBy(x => x.Id);
      List<GenresViewModel> returnObj = _mapper.Map<List<GenresViewModel>>(genres);
      return returnObj;
    }
  }

  public class GenresViewModel
  {
    public int Id { get; set; }
    public string Name { get; set; }
  }
}