using CountryStateCity.Models;
using CountryStateCity.Models.Dtos.Profile;
using WebApplication1.Models;

public class ProfileRepository : IProfileRepository
{
    private readonly DataContext _context;

    public ProfileRepository(DataContext context)
    {
        _context = context;
    }

    public List<GetProfileDto> GetAll()
    {
        return _context.Profiles.Select(x => new GetProfileDto
        {
            Id = x.Id,
            Name = x.Name,
            Email = x.Email
        }).ToList();
    }

    public GetProfileDto GetById(int id)
    {
        var data = _context.Profiles.Find(id);

        if (data == null)
            throw new Exception("Profile not found");

        return new GetProfileDto
        {
            Id = data.Id,
            Name = data.Name,
            Email = data.Email
        };
    }

    public void Add(GetProfileDto input)
    {
        var existing = _context.Profiles
            .FirstOrDefault(x => x.Email == input.Email);

        if (existing != null)
            throw new Exception("Email already exists");

        var profile = new Profile
        {
            Name = input.Name,
            Email = input.Email
        };

        _context.Profiles.Add(profile);
        _context.SaveChanges();
    }

    public void Update(int id, GetProfileDto input)
    {
        var existing = _context.Profiles.Find(id);

        if (existing == null)
            throw new Exception("Profile not found");

        existing.Name = input.Name;
        existing.Email = input.Email;

        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var data = _context.Profiles.Find(id);

        if (data == null)
            throw new Exception("Profile not found");

        _context.Profiles.Remove(data);
        _context.SaveChanges();
    }
}








//using CountryStateCity.Models;
//using CountryStateCity.Models.Dtos.Profile;
//using WebApplication1.Models;

//public class ProfileRepository : IProfileRepository
//{
//    private readonly DataContext _context;

//    public ProfileRepository(DataContext context)
//    {
//        _context = context;
//    }

//    public List<GetProfileDto> GetAll()
//    {
//        return _context.Profiles.Select(x => new GetProfileDto
//        {
//            Id = x.Id,
//            Name = x.Name,
//            Email = x.Email
//        }).ToList();
//    }
//    //public List<Profile> GetAll()
//    //{
//    //    return _context.Profiles.ToList();
//    //}

//    public Profile GetById(int id)
//    {
//        return _context.Profiles.Find(id);
//    }

//    public void Add(CreateUpdateProfileDto input)
//    {
//        var existing = _context.Profiles
//            .FirstOrDefault(x => x.Email == input.Email);
//        if (existing != null)
//        {
//            throw new Exception("Email already exists");
//        }
//        Profile profile = new Profile();
//        profile.Name = input.Name;
//        profile.Email = input.Email;
//        _context.Profiles.Add(profile);
//        _context.SaveChanges();
//    }

//    public void Update(int id, CreateUpdateProfileDto input)
//    {
//        var existing = _context.Profiles.Find(id);
//        if (existing == null)
//        {
//            throw new Exception("Profile not found");
//        }
//        existing.Name = input.Name;
//        existing.Email = input.Email;
//        _context.Profiles.Update(existing);
//        _context.SaveChanges();
//    }
//    //public void Update(Profile profile)
//    //{
//    //    _context.Profiles.Update(profile);
//    //    _context.SaveChanges();
//    //}

//    public void Delete(int id)
//    {
//        var data = _context.Profiles.Find(id);
//        if (data != null)
//        {
//            _context.Profiles.Remove(data);
//            _context.SaveChanges();
//        }
//    }

//    List<GetProfileDto> IProfileRepository.GetAll()
//    {
//        throw new NotImplementedException();
//    }

//    public void Update(UpdateProfileDto input)
//    {
//        throw new NotImplementedException();
//    }

//    internal object GetAll(GetProfileDto input)
//    {
//        throw new NotImplementedException();
//    }

//    GetProfileDto IProfileRepository.GetById(int id)
//    {
//        throw new NotImplementedException();
//    }

//    public void Add(GetProfileDto input)
//    {
//        throw new NotImplementedException();
//    }

//    public void Update(int id, GetProfileDto input)
//    {
//        throw new NotImplementedException();
//    }
//}








