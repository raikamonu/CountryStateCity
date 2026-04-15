using CountryStateCity.Models;
using WebApplication1.Models;

public interface IProfileRepository
{
    List<Profile> GetAll();
    Profile GetById(int id);
    void Add(Profile profile);
    void Update(Profile profile);
    void Delete(int id);
}