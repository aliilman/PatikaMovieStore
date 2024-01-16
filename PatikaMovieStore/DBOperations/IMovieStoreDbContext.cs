using Microsoft.EntityFrameworkCore;
using PatikaMovieStore.Entities;

namespace PatikaMovieStore.DBOperations
{
  public interface IMovieStoreDbContext
  {
    DbSet<Movie> Movies { get; set; }
    DbSet<Genre> Genres { get; set; }
    DbSet<Actor> Actors { get; set; }
    DbSet<Director> Directors { get; set; }
    DbSet<User> Users { get; set; }
    DbSet<Order> Orders { get; set; }
    int SaveChanges();
  }
}