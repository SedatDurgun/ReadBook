using DomainLayer.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Repositories.Abstract
{
    public interface IBaseRepository<TEntity> where TEntity : class , IEntity
    {
        Task AddAsync(TEntity entity);
        Task<bool> UpdateAsync(TEntity entity);

        Task<bool> DeleteAsync(int id);

        Task<TEntity> FindAsync(int id);

        Task<IEnumerable<TEntity>> GetAllActiveAsync();

        //SoftDelete 
        Task<IEnumerable<TEntity>> GetAllInactiveAsync();
      

        IQueryable<TEntity> GetAllActiveInclude();



    }
    
}
