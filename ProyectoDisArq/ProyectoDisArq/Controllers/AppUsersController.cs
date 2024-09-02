using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoDisArq.Persistence;
using ProyectoDisArq.Repositories.Interfaces;
using ProyectoDisArq.Utilities;
using System.Security.Claims;

namespace ProyectoDisArq.Controllers
{
    [Authorize(Roles =DS.Admin_Role)]
    public class AppUsersController : Controller
    {
        private readonly IUnitWork _unitWork;
        private readonly ProyectoDisArqContext _context;

        public AppUsersController(IUnitWork unitWork, ProyectoDisArqContext context)
        {
            _unitWork = unitWork;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        #region API para Javascript
        /// <summary>
        /// Lista todos los usuarios
        /// </summary>
        /// <returns>Json</returns>
        public async Task<IActionResult> ListarTodos()
        {
            var claimsIdentity = (ClaimsIdentity)this.User.Identity; // Usuario logueado
            var actualUser = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            // Todos los usuarios menos el que inicio sesión
            var users = await _unitWork.AppUser.ObtenerTodosAsync(filter: u => u.Id != actualUser.Value);

            // Recupar los roles
            var userRoles = await _context.UserRoles.ToListAsync();
            var roles = await _context.Roles.ToListAsync();

            foreach (var user in users)
            {
                var roleId = userRoles.FirstOrDefault(u => u.UserId == user.Id).RoleId;
                user.Role = roles.FirstOrDefault(u => u.Id == roleId).Name;
            }

            return Json(new { data = users });
        }
        #endregion
    }
}
