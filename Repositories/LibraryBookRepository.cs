using System.Collections.Generic;
using System.Data;
using Dapper;
using libraryapi.Models;

namespace libraryapi.Repositories
{
  public class LibraryBookRepository
  {
    private readonly IDbConnection _db;
    public LibraryBookRepository(IDbConnection db)
    {
      _db = db;

    }



    //GetBooksByLibraryId
    public IEnumerable<Book> GetBooksByLibraryId(int id)
    {
      return _db.Query<Book>($@"
        SELECT * FROM librarybooks lb
        INNER JOIN book b ON b.id = lb.bookId
        WHERE (libraryId = @id);
      ", new { id });
    }

    //GetLibrariesByBookId
    public IEnumerable<Library> GetLibrariesByBookId(int id)
    {
      return _db.Query<Library>($@"
        SELECT * FROM librarybooks lb
        INNER JOIN library l ON l.id = lb.libraryId
        WHERE (bookId = @id);
      ", new { id });
    }


    //AddLibraryBook
    public LibraryBook AddLibraryBook(LibraryBook lb)
    {
      int id = _db.ExecuteScalar<int>(@"
      INSERT INTO LibraryBooks(bookId, libraryId)
      VALUES(@BookId, @LibraryId);
      SELECT LAST_INSERT_ID();
      ", lb);
      lb.Id = id;
      return lb;
    }

    //DeleteLibraryBook

    public bool DeleteLibraryBook(LibraryBook lb)
    {
      int success = _db.Execute(@"DELETE FROM LibraryBooks WHERE bookId = @BookId AND libraryId = @LibraryId", lb);
      return success != 0;

    }


  }
}