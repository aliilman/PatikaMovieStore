using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PatikaMovieStore.Entities;

namespace PatikaMovieStore.DBOperations
{
  public class DataGenerator
  {
    public static void Initialize(IServiceProvider serviceProvider)
    {
      using (var context = new MovieStoreDbContext(serviceProvider.GetRequiredService<DbContextOptions<MovieStoreDbContext>>()))
      {
        if (context.Movies.Any())
          return;

        context.Genres.AddRange(
          new Genre { Name = "Aksiyon" },
          new Genre { Name = "Komedi" },
          new Genre { Name = "Dram" },
          new Genre { Name = "Fantastik" },
          new Genre { Name = "Korku" },
          new Genre { Name = "Gizem" },
          new Genre { Name = "Romantik" });
        context.SaveChanges();

        context.Directors.AddRange(
          new Director { Name = "Nuri Bilge", LastName = "Ceylan" },
          new Director { Name = "Ferzan", LastName = "Özpetek" },
          new Director { Name = "Yılmaz", LastName = "Erdoğan" },
          new Director { Name = "Reha", LastName = "Erdoğan" },
          new Director { Name = "Fatih", LastName = "Akın" },
          new Director { Name = "Semih", LastName = "Kaplanoğlu" });
        context.SaveChanges();

        context.Actors.AddRange(
          new Actor { Name = "Haluk", LastName = "Bilginer" },
          new Actor { Name = "Tuba", LastName = "Büyüküstün" },
          new Actor { Name = "Cem", LastName = "Yılmaz" },
          new Actor { Name = "Metin", LastName = "Akdülger" },
          new Actor { Name = "Bergüzar", LastName = "Korel" },
          new Actor { Name = "Kenan", LastName = "İmirzalıoğlu" },
          new Actor { Name = "Nurgül", LastName = "Yeşilçay" },
          new Actor { Name = "Engin", LastName = "Akyürek" },
          new Actor { Name = "Tansu", LastName = "Biçer" },
          new Actor { Name = "Melisa", LastName = "Sözen" },
          new Actor { Name = "Çetin", LastName = "Tekindor" },
          new Actor { Name = "Hazal", LastName = "Kaya" },
          new Actor { Name = "Burak", LastName = "Özçivit" },
          new Actor { Name = "Serenay", LastName = "Sarıkaya" });
        context.SaveChanges();

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
        context.SaveChanges();

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
        context.SaveChanges();
      }
    }
  }
}
