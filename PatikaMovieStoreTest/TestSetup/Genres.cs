

using PatikaMovieStore.DBOperations;
using PatikaMovieStore.Entities;

namespace TestSetup
{
  public static class Genres
  {
    public static void AddGenres(this MovieStoreDbContext context)
    {
      context.Genres.AddRange(
          new Genre { Name = "Aksiyon" },
          new Genre { Name = "Komedi" },
          new Genre { Name = "Dram" },
          new Genre { Name = "Fantastik" },
          new Genre { Name = "Korku" },
          new Genre { Name = "Gizem" },
          new Genre { Name = "Romantik" });
    }
  }
}