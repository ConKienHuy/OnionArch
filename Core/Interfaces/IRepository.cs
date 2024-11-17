namespace Core.Interfaces;

public interface IRepository<T> where T : class
{
    T GetById(int id);
    IEnumerable<T> GetAll();
    bool Add(T entity);
    bool Update(T entity);
    bool Delete(int id);
}