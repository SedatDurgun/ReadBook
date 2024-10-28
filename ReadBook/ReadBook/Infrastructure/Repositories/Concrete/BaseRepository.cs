using DomainLayer.Entities.Abstract;

using DomainLayer.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.Concrete
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity :class , IEntity
    {
        protected readonly LibraryContext _db;
        protected DbSet<TEntity> _table;

        public BaseRepository(LibraryContext db )
        {
            _db = db;
            _table = db.Set<TEntity>();
        }

        public async Task AddAsync(TEntity entity)
        {
            entity.AddTime = DateTime.Now;
            entity.IsRegistered= DomainLayer.Enums.IsRegistered.Active;
            
            await _table.AddAsync(entity);
            await _db.SaveChangesAsync();
        }
        public async Task<bool> UpdateAsync(TEntity entity)
        {
            //tarih hatası alıran ekleme yap
            
            entity.UpdateTime = DateTime.Now;
            entity.IsRegistered= DomainLayer.Enums.IsRegistered.Update;

            _db.Update(entity);
            return await _db.SaveChangesAsync()>0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            TEntity entity  = await FindAsync(id);
            entity.DeleteTime = DateTime.Now;
            entity.IsRegistered = DomainLayer.Enums.IsRegistered.Passive;

            _db.Update(entity);

            return await _db.SaveChangesAsync() > 0;
        }

        public async Task<TEntity> FindAsync(int id)
        {
            return await _table.FindAsync(id);
        }

        public async Task<IEnumerable<TEntity>> GetAllActiveAsync()
        {
            return await _table.Where(x => x.IsRegistered != DomainLayer.Enums.IsRegistered.Passive).ToListAsync();
        }

        public  IQueryable<TEntity> GetAllActiveInclude()
        {
            return _table.Where(x => x.IsRegistered != DomainLayer.Enums.IsRegistered.Passive);
        }

        public async Task<IEnumerable<TEntity>> GetAllInactiveAsync()
        {
            return await _table.Where(x=>x.IsRegistered== DomainLayer.Enums.IsRegistered.Passive).ToListAsync();
        }

       

       
    }
}
