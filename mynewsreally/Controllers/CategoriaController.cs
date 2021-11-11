using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mynewsreally.Data;
using mynewsreally.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mynewsreally.Controllers
{
    public class CategoriaController : Controller
    {
        private readonly mynewsreallyContext context;
        public CategoriaController(mynewsreallyContext context)
        {
            this.context = context;
        }
        [Route("Categoria/{id}")]
        public IActionResult Index(int? id)
        {
            List<Post> posts = context.Noticias.Where(x => x.CategoriaID == id)
                            .ToList();
            ViewBag.Categoria = context.Categorias.Where(x => x.CategoriaID == id).FirstOrDefault().Nombre;
            List<Categoria> categorias = context.Categorias.ToList();
            ViewBag.Categorias = categorias;
            return View(posts);
        }
    }
}
