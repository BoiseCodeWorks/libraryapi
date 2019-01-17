using System.ComponentModel.DataAnnotations;

namespace libraryapi.Models
{

  public class LibraryBook
  {
    public int Id { get; set; }
    [Required]
    public int LibraryId { get; set; }
    [Required]
    public int BookId { get; set; }
  }



  public class Library
  {

    public int Id { get; set; }

    public string Name { get; set; }

    public string City { get; set; }
  }
}