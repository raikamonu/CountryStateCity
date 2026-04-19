using CountryStateCity.Models;
using CountryStateCity.Models.Dtos.Profile;
using WebApplication1.Models;

public interface IProfileRepository
{
    List<GetProfileDto> GetAll();
    GetProfileDto GetById(int id);
    void Add(GetProfileDto input);
    void Update(int id,  GetProfileDto input);
    void Delete(int id);


}









//using CountryStateCity.Models;
//using CountryStateCity.Models.Dtos.Profile;
//using WebApplication1.Models;

//public interface IProfileRepository
//{
//    List<GetProfileDto> GetAll();
//    Profile GetById(int id);
//    void Add(CreateUpdateProfileDto input);
//    void Update(UpdateProfileDto input);
//    void Delete(int id);



//}
