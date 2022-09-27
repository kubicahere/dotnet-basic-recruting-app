namespace MatchDataManager.Api.Repositories
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAllData();
        T GetDataById(Guid id);
        IEnumerable<T> GetDataByName(string name);

        bool Add(T data);
        bool Update(T data);
        bool Delete(T data);
        bool Save();
    }
}
