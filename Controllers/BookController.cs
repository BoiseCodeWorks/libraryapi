using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using libraryapi.Models;
using libraryapi.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace libraryapi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class BooksController : ControllerBase
  {
    private readonly BookRepository _repo;

    public BooksController(BookRepository repo)
    {
      _repo = repo;
    }


    // GET api/values
    [HttpGet]
    public ActionResult<IEnumerable<Book>> Get()
    {
      return Ok(_repo.GetAll());
    }

    // GET api/values/5
    [HttpGet("{id}")]
    public ActionResult<Book> Get(int id)
    {
      Book result = _repo.GetById(id);
      if (result != null)
      {
        return Ok(result);
      }
      return BadRequest();
    }

    // POST api/values
    [HttpPost]
    public ActionResult<Book> Post([FromBody] Book value)
    {
      Book result = _repo.AddBook(value);
      return Created("/api/book/" + result.Id, result);
    }

    // PUT api/values/5
    // [HttpPut("{id}")]
    // public void Put(int id, [FromBody] string value)
    // {
    // }

    // DELETE api/values/5
    [HttpDelete("{id}")]
    public ActionResult<string> Delete(int id)
    {
      if (_repo.DeleteBook(id))
      {
        return Ok("Successfully deleted!");
      }
      return BadRequest("Unable to delete!");
    }
  }
}
