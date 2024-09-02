using Microsoft.EntityFrameworkCore;
using ProyectoDisArq.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ProyectoDisArq.Persistence;

namespace ProyectoDisArq.Repositories.Implementations
{
    public class RepositorioBase<T> : IRepositorioBase<T> where T: class
    {
        private readonly ProyectoDisArqContext _db;
        internal DbSet<T> dbSet;
        public RepositorioBase(ProyectoDisArqContext db)
        {
            _db = db;
            this.dbSet = _db.Set<T>();
        }
        public async Task<T> ObtenerAsync(int id)
        {
            return await dbSet.FindAsync(id);
        }
        public async Task AgregarAsync(T entity)
        {
            await dbSet.AddAsync(entity); 
        }

        public void Eliminar(T entity)
        {
            dbSet.Remove(entity);
        }

        //public void EliminarRango(IEnumerable<T> entity)
        //{
        //    dbSet.RemoveRange(entity);
        //}
        public async Task<T> ObtenerPrimeroAsync(
            Expression<Func<T, bool>> filter = null,
            string includeProperties = null,
            bool isTracking = true)
        {
            IQueryable<T> query = dbSet;
            if (filter is not null)
                query = query.Where(filter);

            if (includeProperties is not null)
            {
                foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }

            if (!isTracking)
                query = query.AsNoTracking();

            return await query.FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<T>> ObtenerTodosAsync(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = null,
            bool isTracking = true)
        {
            IQueryable<T> query = dbSet;
            if (filter is not null)
                query = query.Where(filter); // select * from where

            if (includeProperties is not null)
            {
                foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty); // ejemplo: "Category,Publisher"
                }
            }

            if (orderBy is not null)
                query = orderBy(query);

            if (!isTracking)
                query = query.AsNoTracking();

            return await query.ToListAsync();
        }
    }
}
