using System.ComponentModel.DataAnnotations.Schema;

namespace PatikaMovieStore.Entities
{
  public class Genre
  {
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string Name { get; set; }
    public bool IsActive { get; set; } = true;
  }
}