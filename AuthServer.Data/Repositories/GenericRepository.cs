using AuthServer.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AuthServer.Data.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly DbContext _appDbContext;
        private readonly DbSet<TEntity> _dbSet;

        public GenericRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
            _dbSet = appDbContext.Set<TEntity>();
        }

        public async Task AddAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);

        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {//Bura direk datayı veritabanına atıyor IEnumerable sayesinde.
            return await _dbSet.ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity != null)
            {//entity boşsa track edilmesin diyoruz
                _appDbContext.Entry(entity).State = EntityState.Detached;
                return null;
            }
            return entity;
        }

        public void Remove(TEntity entity)
        {
            _dbSet.Remove(entity);//Remove dediğinde şuan silinmiyor savecahnges() metoduyla silinecek.
        }

        public TEntity Update(TEntity entity)
        {
            _appDbContext.Entry(entity).State = EntityState.Modified;
            return entity;
        }

        public IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> expression)
        {//burada Orderby where sorgulama yapacagız için IQueryable kullandık.
            return _dbSet.Where(expression);
        }
    }
}
