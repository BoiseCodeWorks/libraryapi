using System.Collections.Generic;
using System.Data;
using Dapper;
using libraryapi.Models;

namespace libraryapi.Repositories
{
  public class BookRepository
  {
    private readonly IDbConnection _db;
    public BookRepository(IDbConnection db)
    {
      _db = db;

    }
    //GetAll
    public IEnumerable<Book> GetAll()
    {
      return _db.Query<Book>("SELECT * FROM Book");
    }

    //GetById

    public Book GetById(int id)
    {
      return _db.QueryFirstOrDefault<Book>($"SELECT * FROM Book WHERE id = @id", new { id });
    }

    //AddBook
    public Book AddBook(Book newBook)
    {
      int id = _db.ExecuteScalar<int>(@"
      INSERT INTO Book(title, description)
      VALUES(@Title, @Description);
      SELECT LAST_INSERT_ID();
      ", newBook);
      newBook.Id = id;
      return newBook;
    }

    //DeleteBook

    public bool DeleteBook(int id)
    {
      int success = _db.Execute(@"DELETE FROM Book WHERE id = @id", new { id });
      return success != 0;

    }


  }
}