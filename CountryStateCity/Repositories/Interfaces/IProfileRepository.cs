using CountryStateCity.Models;
using CountryStateCity.Models.Dtos.Profile;
using WebApplication1.Models;

public interface IProfileRepository
{
    List<GetProfileDto> GetAll();
    Profile GetById(int id);
    void Add(CreateUpdateProfileDto input);
    void Update(UpdateProfileDto input);
    void Delete(int id);
   
    

}
