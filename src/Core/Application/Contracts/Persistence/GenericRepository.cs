namespace Smashup.Application.Contracts.Persistence;

public interface GenericRepository<T> where T : class
{
  Task<T> FindOneById(string id);
  Task<IReadOnlyList<T>> FindAll();

  Task<bool> Exists(string id);

  Task<T> Add(T entity);

  Task UpdateOne(T entity);

  Task DeleteById(string id);
}
