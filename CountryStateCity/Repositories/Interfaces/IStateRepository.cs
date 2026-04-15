using WebApplication1.Models;

public interface IStateRepository
{
    List<State> GetAll();
    State GetById(int id);
    void Add(State state);
    void Update(State state);
    void Delete(int id);
}