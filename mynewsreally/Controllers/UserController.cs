using Microsoft.AspNetCore.Mvc;
using mynewsreally.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using mynewsreally.Areas.Identity.Data;
using mynewsreally.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace mynewsreally.Controllers
{
    [Authorize( Roles = "SuperAdmin")]
    public class UserController : Controller
    {
        private readonly mynewsreallyContext _context;
        private readonly UserManager<mynewsreallyUser> _userManager;
        public UserController(mynewsreallyContext context, UserManager<mynewsreallyUser> userManager)
        {
            this._context = context;
            this._userManager = userManager;
        }
        public IActionResult Index()
        {
            List<UserRole> usuarios = (from u in _context.Users
                            join ur in _context.UserRoles on u.Id equals ur.UserId
                            join r in _context.Roles on ur.RoleId equals r.Id
                            select new UserRole
                            {
                                UserId= u.Id,
                                UserName = u.UserName,
                                RoleId = ur.RoleId,
                                RolName = r.Name
                            }).ToList();
            return View(usuarios); 
        }

        
        public IActionResult Usuario(string idUser, string idRole, string? idError = "1")
        {
            if (idError=="0")
            { 
                ViewBag.Mensaje = "El nombre usuario ya existe, por favor elegí otro.";
            }
            var r = _context.Roles.ToList();
            List<SelectListItem> Roles = r.ConvertAll(d => {
                return new SelectListItem() {
                    Text = d.Name.ToString(),
                    Value = d.Id.ToString(),
                    Selected = false
                };
            });

            UserRole u = new UserRole {
                UserId = idUser,
                UserName = _context.Users.Where(x => x.Id == idUser).FirstOrDefault().UserName,
                RoleId = idRole,
                RolName = _context.Roles.Where(x => x.Id == idRole).FirstOrDefault().Name
            };

            ViewBag.Roles = Roles;
            return View(u);
        }

        public IActionResult Actualizar(UserRole userRole)
        {
            try
            {
                var userRol = _context.UserRoles.Where(x => x.UserId == userRole.UserId).FirstOrDefault();
                _context.UserRoles.Remove(userRol);
                mynewsreallyUser user = _context.Users.Where(x => x.Id == userRole.UserId).FirstOrDefault();
                user.UserName = userRole.UserName;
                user.NormalizedUserName = userRole.UserName.ToUpper();
                _context.SaveChanges();
                Task<IdentityResult> result1 = _userManager.AddToRoleAsync(user, _context.Roles.Where(x => x.Id == userRole.RoleId).FirstOrDefault().NormalizedName.ToString());
                result1.Wait();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception )
            {
                return RedirectToAction("Usuario","User",new { idUser= userRole.UserId, idRole = userRole.RoleId ,idError = "0" });
            }
        }

        
        public IActionResult Borrar(string id)
        {
            mynewsreallyUser user = _context.Users.Where(x => x.Id == id).FirstOrDefault();
            _context.Users.Remove(user);
            var userRole = _context.UserRoles.Where(x => x.UserId == id).FirstOrDefault();
            _context.UserRoles.Remove(userRole);
            _context.SaveChanges();
                
           return RedirectToAction("Index","User");
           
        }



    }
}   

