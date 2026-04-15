using WebApplication1.Models;

public class CountryRepository : ICountryRepository
{
    private readonly DataContext _context;

    public CountryRepository(DataContext context)
    {
        _context = context;
    }

    public List<Country> GetAll()
    {
        return _context.Countries.ToList();
    }

    public Country GetById(int id)
    {
        return _context.Countries.Find(id);
    }

    public void Add(Country country)
    {
        _context.Countries.Add(country);
        _context.SaveChanges();
    }

    public void Update(Country country)
    {
        _context.Countries.Update(country);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var data = _context.Countries.Find(id);
        if (data != null)
        {
            _context.Countries.Remove(data);
            _context.SaveChanges();
        }
    }
}