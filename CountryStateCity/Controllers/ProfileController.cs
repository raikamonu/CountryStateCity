using CountryStateCity.Models.Dtos.Profile;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class ProfileController : ControllerBase
{
    private readonly IProfileRepository _repo;

    public ProfileController(IProfileRepository repo)
    {
        _repo = repo;
    }

    [HttpPost]
    public IActionResult Add(GetProfileDto input)
    {
        try
        {
            _repo.Add(input);
            return Ok("Inserted successfully");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var data = _repo.GetAll();
        return Ok(data);
    }

  
    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        try
        {
            var data = _repo.GetById(id);
            return Ok(data);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

 
    [HttpPut("{id}")]
    public IActionResult Update(int id, GetProfileDto input)
    {
        try
        {
            _repo.Update(id, input);
            return Ok("Updated successfully");
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
            return Ok("Deleted successfully");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}










//using CountryStateCity.Models;
//using CountryStateCity.Models.Dtos.Profile;
//using Microsoft.AspNetCore.Mvc;
//using WebApplication1.Models;

//[Route("api/[controller]")]
//[ApiController]
//public class ProfileController : ControllerBase
//{
//    private readonly ProfileRepository _repo;

//    public ProfileController(ProfileRepository repo)
//    {
//        _repo = repo;
//    }

//    [HttpPost]
//    public IActionResult Add(CreateUpdateProfileDto input)
//    {
//        try
//        {
//            _repo.Add(input);

//            return Ok(new
//            {
//                message = "Inserted successfully"
//            });
//        }
//        catch (Exception ex)
//        {
//            return BadRequest(new
//            {
//                error = ex.Message
//            });
//        }
//    }

//    [HttpGet]
//    public IActionResult GetAll(GetProfileDto input)
//    {
//        var data = _repo.GetAll(input);
//        return Ok(data);
//    } 


//    [HttpPut]
//    public IActionResult Update(UpdateProfileDto input)
//    {
//        try
//        {
//            _repo.Update(input);

//            return Ok(new
//            {
//                message = "Updated successfully"
//            });
//        }
//        catch (Exception ex)
//        {
//            return BadRequest(new
//            {
//                error = ex.Message
//            });
//        }
//    }

//}