using MatchDataManager.Api.Database;
using MatchDataManager.Api.Models;

namespace MatchDataManager.Api.Repositories;

public class TeamsRepository : IRepository<Team>
{
    private readonly DataContext _dataContext;

    public TeamsRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public IEnumerable<Team> GetAllData()
    {
        return _dataContext.Teams;
    }
    public Team GetDataById(Guid id)
    {
        return _dataContext.Teams.Where(x => x.Id == id).FirstOrDefault();
    }
    public IEnumerable<Team> GetDataByName(string name)
    {
        return _dataContext.Teams.Where(x =>x.Name == name).ToList();
    }
    public bool Add(Team team)
    {
        team.Id = Guid.NewGuid();
        _dataContext.Add(team);

        return Save();
    }
    public bool Update(Team team)
    {
        var existingTeam = _dataContext.Teams.FirstOrDefault(x => x.Id == team.Id);
        if (existingTeam is null || team is null)
        {
            throw new ArgumentException("Team doesn't exist.", nameof(team));
        }
        existingTeam.CoachName = team.CoachName;
        existingTeam.Name = team.Name;

        return Save();
    }
    public bool Delete(Team team)
    {
        _dataContext.Remove(team);

        return Save();
    }
    public bool Save()
    {
        var save = _dataContext.SaveChanges();
        return save > 0 ? true : false;
    }
}