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
  public class LibraryController : ControllerBase
  {
    private readonly LibraryRepository _repo;

    public LibraryController(LibraryRepository repo)
    {
      _repo = repo;
    }


    // GET api/values
    [HttpGet]
    public ActionResult<IEnumerable<Library>> Get()
    {
      return Ok(_repo.GetAll());
    }

    // GET api/values/5
    [HttpGet("{id}")]
    public ActionResult<Library> Get(int id)
    {
      Library result = _repo.GetById(id);
      if (result != null)
      {
        return Ok(result);
      }
      return BadRequest();
    }

    // POST api/values
    [HttpPost]
    public ActionResult<Library> Post([FromBody] Library value)
    {
      Library result = _repo.AddLibrary(value);
      return Created("/api/library/" + result.Id, result);
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
      if (_repo.DeleteLibrary(id))
      {
        return Ok("Successfully deleted!");
      }
      return BadRequest("Unable to delete!");
    }
  }
}
