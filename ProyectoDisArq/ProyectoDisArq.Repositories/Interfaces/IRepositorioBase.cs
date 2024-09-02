using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoDisArq.Repositories.Interfaces
{
    public interface IRepositorioBase<T> where T : class
    {
        Task<T> ObtenerAsync(int id);
        Task<IEnumerable<T>> ObtenerTodosAsync(Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = null,
            bool isTracking = true
            );
        Task<T> ObtenerPrimeroAsync(
            Expression<Func<T, bool>> filter = null,
            string includeProperties = null,
            bool isTracking = true
            );
        Task AgregarAsync(T entity);
        void Eliminar(T entity);
        //void EliminarRango(IEnumerable<T> entity);
    }
}
