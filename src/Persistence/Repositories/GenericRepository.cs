using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using Smashup.Application.Contracts.Persistence;

namespace Smashup.Persistence.Repositories
{
  public class GenericRepositorySQLite<T> : GenericRepository<T> where T : class
  {
    private readonly SmashupDbContext _dbContext;
    public GenericRepositorySQLite(SmashupDbContext dbContext)
    {
      this._dbContext = dbContext;
    }

    public async Task<T> Add(T entity)
    {
      await this._dbContext.AddAsync(entity);
      await this._dbContext.SaveChangesAsync();
      return entity;
    }

    public async Task DeleteById(string id)
    {
      var entity = await this.FindOneById(id);
      this._dbContext.Set<T>().Remove(entity);
      await this._dbContext.SaveChangesAsync();
    }

    public async Task<bool> Exists(string id)
    {
      var entity = await this._dbContext.FindAsync<T>(id);
      return entity != null;
    }

    public async Task<IReadOnlyList<T>> FindAll()
    {
      return await this._dbContext.Set<T>().ToListAsync();
    }

    public async Task<T> FindOneById(string id)
    {
      return await this._dbContext.Set<T>().FindAsync(id);
    }

    public async Task UpdateOne(T entity)
    {
      this._dbContext.Entry<T>(entity).State = EntityState.Modified;
      await this._dbContext.SaveChangesAsync();
    }
  }
}