using System.Collections.Generic;
using System.Data;
using Dapper;
using libraryapi.Models;

namespace libraryapi.Repositories
{
  public class LibraryRepository
  {
    private readonly IDbConnection _db;
    public LibraryRepository(IDbConnection db)
    {
      _db = db;

    }
    //GetAll
    public IEnumerable<Library> GetAll()
    {
      return _db.Query<Library>("SELECT * FROM Library");
    }

    //GetById

    public Library GetById(int id)
    {
      return _db.QueryFirstOrDefault<Library>($"SELECT * FROM Library WHERE id = @id", new { id });
    }

    //AddLibrary
    public Library AddLibrary(Library newLibrary)
    {
      int id = _db.ExecuteScalar<int>(@"
      INSERT INTO Library(name, city)
      VALUES(@Name, @City);
      SELECT LAST_INSERT_ID();
      ", newLibrary);
      newLibrary.Id = id;
      return newLibrary;
    }

    //DeleteLibrary

    public bool DeleteLibrary(int id)
    {
      int success = _db.Execute(@"DELETE FROM Library WHERE id = @id", new { id });
      return success != 0;

    }


  }
}