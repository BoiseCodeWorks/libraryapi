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
  public class AuthorsController : ControllerBase
  {
    private readonly AuthorRepository _repo;

    public AuthorsController(AuthorRepository repo)
    {
      _repo = repo;
    }


    // GET api/values
    [HttpGet]
    public ActionResult<IEnumerable<Author>> Get()
    {
      return Ok(_repo.GetAll());
    }

    // GET api/values/5
    [HttpGet("{id}")]
    public ActionResult<Author> Get(int id)
    {
      Author result = _repo.GetById(id);
      if (result != null)
      {
        return Ok(result);
      }
      return BadRequest();
    }

    // POST api/values
    [HttpPost]
    public ActionResult<Author> Post([FromBody] Author value)
    {
      Author result = _repo.AddAuthor(value);
      return Created("/api/author/" + result.Id, result);
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
      if (_repo.DeleteAuthor(id))
      {
        return Ok("Successfully deleted!");
      }
      return BadRequest("Unable to delete!");
    }
  }
}
