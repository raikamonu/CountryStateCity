using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

public class StateRepository : IStateRepository
{
    private readonly DataContext _context;

    public StateRepository(DataContext context)
    {
        _context = context;
    }

    public List<State> GetAll()
    {
        return _context.States.Include(x => x.Country).ToList();
    }

    public State GetById(int id)
    {
        return _context.States.Include(x => x.Country)
                              .FirstOrDefault(x => x.Id == id);
    }

    public void Add(State state)
    {
        _context.States.Add(state);
        _context.SaveChanges();
    }

    public void Update(State state)
    {
        _context.States.Update(state);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var data = _context.States.Find(id);
        if (data != null)
        {
            _context.States.Remove(data);
            _context.SaveChanges();
        }
    }
}