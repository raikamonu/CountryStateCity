
using System.Diagnostics.Metrics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly ICountryRepository _repo;

        public CountryController(ICountryRepository repo)
        {
            _repo = repo;
        }


        [HttpGet]
        public ActionResult<List<Country>> GetAll()
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
        public ActionResult GetById(int id)
        {
            try
            {
                var data = _repo.GetById(id);
                if (data == null)
                    return NotFound("Data not found");

                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        [HttpPost]
        public IActionResult Add(Country country)
        {
            try
            {
                _repo.Add(country);
                return Ok("Inserted");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult Update(Country country)
        {
            try
            {
                _repo.Update(country);
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
}



//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using System.Diagnostics.Metrics;
//using WebApplication1.Models;

//namespace WebApplication1.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class CountryController : ControllerBase
//    {
//        private readonly DataContext _context;

//        public CountryController(DataContext context)
//        {
//            _context = context;
//        }

//        [HttpPost]
//        public void Add(Country country)
//        {
//            _context.Countries.Add(country);
//            _context.SaveChanges();
//        }

//        [HttpGet]
//        public List<Country> GetAll()
//        {
//            return _context.Countries.ToList();
//        }

//        [HttpPut]
//        public void Put(Country country)
//        {
//            _context.Update(country);
//            _context.SaveChanges();
//        }

//        [HttpGet("{id}")]
//        public IActionResult GetById(int id)
//        {
//            var country = _context.Countries.Find(id);

//            if (country == null)
//            {
//                return NotFound("Data not found");
//            }

//            return Ok(country);
//        }

//        [HttpDelete("{id}")]
//        public void Delete(int id)
//        {
//            var Country = _context.Countries.Find(id);
//            if (Country != null)
//            {
//                _context.Countries.Remove(Country);
//                _context.SaveChanges();
//            }
//        }

//    }
//}







