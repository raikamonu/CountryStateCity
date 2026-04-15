using CountryStateCity.Models;
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
    public IActionResult Add(Profile profile)
    {
        try
        {
            _repo.Add(profile);

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
    public IActionResult GetAll()
    {
        var data = _repo.GetAll();
        return Ok(data);
    }
}