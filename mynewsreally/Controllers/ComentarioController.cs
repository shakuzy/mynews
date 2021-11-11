using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using mynewsreally.Data;
using mynewsreally.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mynewsreally.Controllers
{
    public class ComentarioController : Controller
    {
        private readonly mynewsreallyContext context;

        public ComentarioController(mynewsreallyContext _context)
        {
            this.context = _context;
        }
        [Authorize]
        public IActionResult Agregar(Comentario comentario)
        {
            context.Comentarios.Add(comentario);
            context.SaveChanges();
            return RedirectToAction("Post", "Post", new { id = comentario.PostID });
        }
        [Authorize]
        public IActionResult Borrar(int id)
        {
            Comentario comentario = context.Comentarios.Where(x => x.ComentarioID == id).FirstOrDefault();
            context.Comentarios.Remove(comentario);
            context.SaveChanges();
            return RedirectToAction("Post", "Post", new { id = comentario.PostID });
        }
        [Authorize(Roles = "SuperAdmin, Admin")]
        public IActionResult BorrarTodosLosComentarios(int id)
        {
            List<Comentario> comentarios = context.Comentarios.Where(x => x.PostID == id).ToList();
            foreach (Comentario comentario in comentarios)
            {
                context.Comentarios.Remove(comentario);

            }
            context.SaveChanges();
            return RedirectToAction("Post", "Post", new { id = id });
        }
    }
}
