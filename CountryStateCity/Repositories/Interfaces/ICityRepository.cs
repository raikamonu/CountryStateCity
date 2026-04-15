using WebApplication1.Models;

public interface ICityRepository
{
    List<City> GetAll();
    City GetById(int id);
    void Add(City city);
    void Update(City city);
    void Delete(int id);
}