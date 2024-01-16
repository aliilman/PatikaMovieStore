using System;
namespace PatikaMovieStore.Services
{
  public class ConsoleLogger : ILoggerService
  {
    public void Write(string message)
    {
      Console.WriteLine("[ConsoleLogger] -  " + message);
    }
  }
}