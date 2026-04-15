
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

[Route("api/[controller]")]
[ApiController]
public class CityController : ControllerBase
{
    private readonly ICityRepository _repo;

    public CityController(ICityRepository repo)
    {
        _repo = repo;
    }

    [HttpGet]
    public ActionResult<List<City>> GetAll()
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
    public IActionResult Add(City city)
    {
        try
        {
            _repo.Add(city);
            return Ok("Inserted");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut]
    public IActionResult Update(City city)
    {
        try
        {
            _repo.Update(city);
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







//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using WebApplication1.Models;

//namespace WebApplication1.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class CItyController : ControllerBase
//    {
//        private readonly DataContext _context;

//        public CItyController(DataContext context)
//        {
//            _context = context;
//        }

//        [HttpPost]
//        public void Add(City city)
//        {
//            _context.Cities.Add(city);
//            _context.SaveChanges();
//        }

//        [HttpGet]
//        public List<City> GetAll()
//        {
//            return _context.Cities.Include(x => x.State).ThenInclude(x => x.Country).ToList();
//        }

//        [HttpPut]
//        public void Put(City city)
//        {
//            _context.Update(city);
//            _context.SaveChanges();
//        }

//        [HttpGet("{id}")]
//        public IActionResult GetById(int id)
//        {
//            var city = _context.Cities.Find(id);

//            if (city == null)
//            {
//                return NotFound("Data not found");
//            }

//            return Ok(city);
//        }

//        [HttpDelete("{id}")]
//        public void Delete(int id)
//        {
//            var City = _context.Cities.Find(id);
//            if (City != null)
//            {
//                _context.Cities.Remove(City);
//                _context.SaveChanges();
//            }
//        }

//    }
//}







