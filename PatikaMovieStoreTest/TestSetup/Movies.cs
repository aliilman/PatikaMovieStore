
using PatikaMovieStore.DBOperations;
using PatikaMovieStore.Entities;

namespace TestSetup
{
  public static class Movies
  {
    public static void AddMovies(this MovieStoreDbContext context)
    {
      context.Movies.AddRange(
         new Movie
          {
            Name = "Uzak",
            GenreId = 6,
            DirectorId = 1,
            Price = 30,
            PublishDate = new DateTime(2002),
            Actors = new List<Actor>()
          },
          new Movie
          {
            Name = "Vizontele",
            GenreId = 3,
            DirectorId = 2,
            Price = 20,
            PublishDate = new DateTime(2001),
            Actors = new List<Actor>()
          },
          new Movie
          {
            Name = "Vizontele Tuuba",
            GenreId = 7,
            DirectorId = 3,
            Price = 10,
            PublishDate = new DateTime(2004),
            Actors = new List<Actor>()
          },
          new Movie
          {
            Name = "Gise Memuru",
            GenreId = 1,
            DirectorId = 4,
            Price = 40,
            PublishDate = new DateTime(2005),
            Actors = new List<Actor>()
          },
          new Movie
          {
            Name = "Gegen die Wand",
            GenreId = 3,
            DirectorId = 5,
            Price = 25,
            PublishDate = new DateTime(2004),
            Actors = new List<Actor>()
          },
          new Movie
          {
            Name = "Bal",
            GenreId = 5,
            DirectorId = 6,
            Price = 15,
            PublishDate = new DateTime(2010),
            Actors = new List<Actor>()
          });
    }
  }
}