
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using WebApplication1.Models;

//namespace WebApplication1.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class StateController : ControllerBase
//    {
//        private readonly DataContext _context;

//        public StateController(DataContext context)
//        {
//            _context = context;
//        }

//        [HttpPost]
//        public void Add(State state)
//        {
//            _context.States.Add(state);
//            _context.SaveChanges();
//        }

//        [HttpGet]
//        public List<State> GetAll()
//        {
//            return _context.States.Include(x => x.Country).ToList();
//        }

//        [HttpPut]
//        public void Put(State state)
//        {
//            _context.Update(state);
//            _context.SaveChanges();
//        }

//        [HttpGet("{id}")]
//        public IActionResult GetById(int id)
//        {
//            var state = _context.States.Find(id);

//            if (state == null)
//            {
//                return NotFound("Data not found");
//            }

//            return Ok(state);
//        }


//        [HttpDelete("{id}")]
//        public void Delete(int id)
//        {
//            var State = _context.States.Find(id);
//            if (State != null)
//            {
//                _context.States.Remove(State);
//                _context.SaveChanges();
//            }
//        }



//    }
//}






using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

[Route("api/[controller]")]
[ApiController]
public class StateController : ControllerBase
{
    private readonly IStateRepository _repo;

    public StateController(IStateRepository repo)
    {
        _repo = repo;
    }

    [HttpGet]
    public ActionResult<List<State>> GetAll()
    {
        try
        {
            return Ok(_repo.GetAll());
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        try
        {
            var data = _repo.GetById(id);
            if (data == null)
                return NotFound("Not Found");

            return Ok(data);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpPost]
    public IActionResult Add(State state)
    {
        try
        {
            _repo.Add(state);
            return Ok("Inserted");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut]
    public IActionResult Update(State state)
    {
        try
        {
            _repo.Update(state);
            return Ok("Updated");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        try
        {
            _repo.Delete(id);
            return Ok("Deleted");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
