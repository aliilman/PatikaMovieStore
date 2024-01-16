using PatikaMovieStore.DBOperations;
using PatikaMovieStore.Entities;

namespace TestSetup
{
  public static class Actors
  {
    public static void AddActors(this MovieStoreDbContext context)
    {
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
    }
  }
}