using CountryStateCity.Models;
using CountryStateCity.Models.Dtos.Profile;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

[Route("api/[controller]")]
[ApiController]
public class ProfileController : ControllerBase
{
    private readonly ProfileRepository _repo;

    public ProfileController(ProfileRepository repo)
    {
        _repo = repo;
    }

    [HttpPost]
    public IActionResult Add(CreateUpdateProfileDto input)
    {
        try
        {
            _repo.Add(input);

            return Ok(new
            {
                message = "Inserted successfully"
            });
        }
        catch (Exception ex)
        {
            return BadRequest(new
            {
                error = ex.Message
            });
        }
    }

    [HttpGet]
    public IActionResult GetAll(GetProfileDto input)
    {
        var data = _repo.GetAll(input);
        return Ok(data);
    }


    [HttpPut]
    public IActionResult Update(UpdateProfileDto input)
    {
        try
        {
            _repo.Update(input);

            return Ok(new
            {
                message = "Updated successfully"
            });
        }
        catch (Exception ex)
        {
            return BadRequest(new
            {
                error = ex.Message
            });
        }
    }

}