using MatchDataManager.Api.Database;
using MatchDataManager.Api.Models;

namespace MatchDataManager.Api.Repositories;

public class LocationsRepository : IRepository<Location>
{
    private readonly DataContext _dataContext;

    public LocationsRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }
    public IEnumerable<Location> GetAllData()
    {
        return _dataContext.Locations.OrderBy(x => x.Id).ToList();
    }
    public Location GetDataById(Guid id)
    {
        return _dataContext.Locations.Where(x => x.Id == id).FirstOrDefault();
    }
    public IEnumerable<Location> GetDataByName(string name)
    {
        return _dataContext.Locations.Where(x => x.Name == name).ToList();
    }
    public bool Add(Location location)
    {
        location.Id = Guid.NewGuid();
        _dataContext.Add(location);

        return Save();
    }
    public bool Update(Location location)
    {
        var existingLocation = _dataContext.Locations.FirstOrDefault(x => x.Id == location.Id);
        if (existingLocation is null || location is null)
        {
            throw new ArgumentException("Location doesn't exist.", nameof(location));
        }
        existingLocation.City = location.City;
        existingLocation.Name = location.Name;

        return Save();
    }
    public bool Delete(Location location)
    {
        _dataContext.Remove(location);

        return Save();
    }
    public bool Save()
    {
        var save = _dataContext.SaveChanges();

        return save > 0? true: false;
    }
}