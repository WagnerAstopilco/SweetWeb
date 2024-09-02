using ProyectoDisArq.Models;
using ProyectoDisArq.Persistence;
using ProyectoDisArq.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoDisArq.Repositories.Implementations
{
    public class AppUserRepository :RepositorioBase<AppUser>,IAppUserRepository
    {
        private readonly ProyectoDisArqContext _db;

        public AppUserRepository(ProyectoDisArqContext db):base(db)
        {
            _db = db;
        }
    }
}
