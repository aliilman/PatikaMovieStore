using PatikaMovieStore.DBOperations;
using PatikaMovieStore.Entities;

namespace TestSetup
{
  public static class Users
  {
    public static void AddUsers(this MovieStoreDbContext context)
    {
      context.Users.AddRange(
          new User
          {
            Name = "Ali",
            LastName = "İlman",
            Email = "ali@gmail.com",
            Password = "123456",
            Movies = new List<Movie>(),
            Genres = new List<Genre>()
          },
          new User
          {
            Name = "Veli",
            LastName = "veli",
            Email = "Veli@hotmail.com",
            Password = "123321",
            Movies = new List<Movie>(),
            Genres = new List<Genre>()
          },
          new User
          {
            Name = "Kamil",
            LastName = "koç",
            Email = "kamilkoç@hotmail.com",
            Password = "111222",
            Movies = new List<Movie>(),
            Genres = new List<Genre>()
          });
    }
  }
}