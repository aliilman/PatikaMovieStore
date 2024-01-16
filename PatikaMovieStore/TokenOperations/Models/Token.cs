using System;

namespace PatikaMovieStore.TokenOperations.Models
{
  public class Token
  {
    public string AccesToken { get; set; }
    public DateTime Expiration { get; set; }
    public string Refreshtoken { get; set; }
  }
}