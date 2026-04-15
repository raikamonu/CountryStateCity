using WebApplication1.Models;

public interface ICountryRepository
{
    List<Country> GetAll();
    Country GetById(int id);
    void Add(Country country);
    void Update(Country country);
    void Delete(int id);
}