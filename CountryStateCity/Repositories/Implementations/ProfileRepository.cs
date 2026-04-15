using CountryStateCity.Models;
using WebApplication1.Models;

public class ProfileRepository : IProfileRepository
{
    private readonly DataContext _context;

    public ProfileRepository(DataContext context)
    {
        _context = context;
    }

    public List<Profile> GetAll()
    {
        return _context.Profiles.ToList();
    }

    public Profile GetById(int id)
    {
        return _context.Profiles.Find(id);
    }

    public void Add(Profile profile)
    {
        // 🔴 Email duplicate check yahi hoga
        var existing = _context.Profiles
            .FirstOrDefault(x => x.Email == profile.Email);

        if (existing != null)
        {
            throw new Exception("Email already exists");
        }

        _context.Profiles.Add(profile);
        _context.SaveChanges();
    }

    public void Update(Profile profile)
    {
        _context.Profiles.Update(profile);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var data = _context.Profiles.Find(id);
        if (data != null)
        {
            _context.Profiles.Remove(data);
            _context.SaveChanges();
        }
    }
}