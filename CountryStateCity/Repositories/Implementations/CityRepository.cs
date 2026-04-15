using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

public class CityRepository : ICityRepository
{
    private readonly DataContext _context;

    public CityRepository(DataContext context)
    {
        _context = context;
    }

    public List<City> GetAll()
    {
        return _context.Cities
            .Include(x => x.State)
            .ThenInclude(x => x.Country)
            .ToList();
    }

    public City GetById(int id)
    {
        return _context.Cities
            .Include(x => x.State)
            .ThenInclude(x => x.Country)
            .FirstOrDefault(x => x.Id == id);
    }

    public void Add(City city)
    {
        _context.Cities.Add(city);
        _context.SaveChanges();
    }

    public void Update(City city)
    {
        _context.Cities.Update(city);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var data = _context.Cities.Find(id);
        if (data != null)
        {
            _context.Cities.Remove(data);
            _context.SaveChanges();
        }
    }
}