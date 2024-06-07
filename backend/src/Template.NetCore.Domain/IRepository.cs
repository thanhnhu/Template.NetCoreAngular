using System;
using System.Collections.Generic;
using System.Threading.Tasks;

/*
 * Repository: Mediates between the domain and data mapping layers 
 * using a collection-like interface for accessing domain objects. 
 * https://martinfowler.com/eaaCatalog/repository.html
 * 
 * This is a generic interface for repositories to be used
 */

namespace Template.NetCore.Domain
{
    public interface IRepository<TEntity> : IDisposable
        //where TEntity : IAggregateRoot
        where TEntity : class
    {
        Task<TEntity> FindById(Guid id);
        Task<List<TEntity>> FindAll();
        Task<TEntity> Add(TEntity entity);
        TEntity Update(TEntity entity);
        Task Remove(Guid id);
        Task<int> SaveChangesAsync();
    }
}
