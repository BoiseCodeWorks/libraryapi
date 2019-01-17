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

    //GetByAuthorId
    public IEnumerable<Book> GetByAuthorId(int id)
    {
      // new id object is an anonymous object and @id pulls the property off of it
      return _db.Query<Book>("SELECT * FROM Book WHERE authorId = @id", new { id });
    }


    //AddBook
    public Book AddBook(Book newBook)
    {
      int id = _db.ExecuteScalar<int>(@"
      INSERT INTO Book(title, description, authorId)
      VALUES(@Title, @Description, @AuthorId);
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