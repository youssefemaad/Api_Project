using DomainLayer.Contracts;
using DomainLayer.Models;
using Presistence.Data;

namespace Presistence.Repository
{
    public class UnitOfWork(StoreDbContext _dbContext) : IUnitOfWork
    {
        private readonly Dictionary<string, object> _repositories= new();
        public IGenaricRepository<TEntity, TKey> GetRepository<TEntity, TKey>() where TEntity : BaseEntity<TKey>
        {
            // Get Type Name
            var typeName = typeof(TEntity).Name;
            // Dictionary<string, object> ==> subject Key [Type Name], Value [object]
            if (_repositories.TryGetValue(typeName,out object? value))
                return (IGenaricRepository<TEntity, TKey>)value;

            else
            {
                // Create Object
                var Repo = new GenericRepository<TEntity, TKey>(_dbContext);

                // Store Object in Dictionary
                _repositories["typeName"] =Repo;

                // Return Object
                return Repo;
            }
        }

        public async Task<int> SaveChangesAsync() => await _dbContext.SaveChangesAsync();
    }
}
