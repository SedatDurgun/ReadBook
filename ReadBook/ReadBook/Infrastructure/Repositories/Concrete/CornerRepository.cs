using DomainLayer.Entities.Concrete;
using DomainLayer.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.Concrete
{
    public class CornerRepository : BaseRepository<Corner>, ICornerRepository
    {
        public CornerRepository(LibraryContext db) : base(db)
        {
        }

        public async Task DeleteFromCornerAsync(int id)
        {
            Corner corner = _table.Find(id);
            _table.Remove(corner);
             await _db.SaveChangesAsync();
        }
    }
}
