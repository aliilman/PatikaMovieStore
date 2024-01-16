
using PatikaMovieStore.DBOperations;
using PatikaMovieStore.Entities;

namespace TestSetup
{
  public static class Directors
  {
    public static void AddDirectors(this MovieStoreDbContext context)
    {
      context.Directors.AddRange(
          new Director { Name = "Nuri Bilge", LastName = "Ceylan" },
          new Director { Name = "Ferzan", LastName = "Özpetek" },
          new Director { Name = "Yılmaz", LastName = "Erdoğan" },
          new Director { Name = "Reha", LastName = "Erdoğan" },
          new Director { Name = "Fatih", LastName = "Akın" },
          new Director { Name = "Semih", LastName = "Kaplanoğlu" });
    }
  }
}