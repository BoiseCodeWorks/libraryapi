using System.Collections.Generic;
using System.Data;
using Dapper;
using libraryapi.Models;

namespace libraryapi.Repositories
{
  public class AuthorRepository
  {
    private readonly IDbConnection _db;
    public AuthorRepository(IDbConnection db)
    {
      _db = db;

    }
    //GetAll
    public IEnumerable<Author> GetAll()
    {
      return _db.Query<Author>("SELECT * FROM Author");
    }

    //GetById

    public Author GetById(int id)
    {
      return _db.QueryFirstOrDefault<Author>($"SELECT * FROM Author WHERE id = @id", new { id });
    }

    //AddAuthor
    public Author AddAuthor(Author newAuthor)
    {
      int id = _db.ExecuteScalar<int>(@"
      INSERT INTO Author(name, bio)
      VALUES(@Name, @Bio);
      SELECT LAST_INSERT_ID();
      ", newAuthor);
      newAuthor.Id = id;
      return newAuthor;
    }

    //DeleteAuthor

    public bool DeleteAuthor(int id)
    {
      int success = _db.Execute(@"DELETE FROM Author WHERE id = @id", new { id });
      return success != 0;

    }


  }
}