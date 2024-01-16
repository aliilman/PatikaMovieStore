using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace PatikaMovieStore.Entities
{
  public class Director
  {
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
  }
}