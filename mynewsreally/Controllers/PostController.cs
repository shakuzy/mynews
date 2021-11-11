using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using mynewsreally.Data;
using mynewsreally.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mynewsreally.Controllers
{
    public class PostController : Controller
    {
        private readonly mynewsreallyContext context;
        public PostController(mynewsreallyContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            List<Post> posts = context.Noticias
                .Include(c => c.Categoria)
                .AsNoTracking()
                .ToList();
            ViewData["Title"] = "Index";

            List<Categoria> categorias = context.Categorias.ToList();
            ViewBag.Categorias = categorias;
            return View(posts);
        }
        public IActionResult Post(int id)
        {
            Post post = context.Noticias.Where(x => x.PostID == id).FirstOrDefault();
            ViewBag.Comentarios = context.Comentarios.Where(x => x.PostID == id).ToList();
            return View(post);
        }

        [Authorize(Roles ="SuperAdmin, Admin")]
        public IActionResult Agregar()
        {
            List<Categoria> categoriass = context.Categorias.ToList();
            List<SelectListItem> items = categoriass.ConvertAll(d => {
                return new SelectListItem()
                {
                    Text = d.Nombre.ToString(),
                    Value = d.CategoriaID.ToString(),
                    Selected = false
                };
            });
            ViewBag.Categoriass = items;
            ViewBag.Categorias = categoriass;
            return View();
        }
        [Authorize(Roles = "SuperAdmin, Admin")]
        public IActionResult Nuevo(Post post)
        {
            context.Noticias.Add(post);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        [Authorize(Roles = "SuperAdmin, Admin")]
        public IActionResult Borrar(int id)
        {
            Post post = context.Noticias.Where(x => x.PostID == id).FirstOrDefault();
            context.Noticias.Remove(post);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        [Authorize(Roles = "SuperAdmin, Admin")]
        public IActionResult Editar(int id)
        {
            Post post = context.Noticias.Where(x => x.PostID == id).FirstOrDefault();
            List<Categoria> categoriass = context.Categorias.ToList();
            List<SelectListItem> items = categoriass.ConvertAll(d => {
                return new SelectListItem()
                {
                    Text = d.Nombre.ToString(),
                    Value = d.CategoriaID.ToString(),
                    Selected = false
                };
            });
            ViewBag.Categoriass = items;
            ViewBag.Categorias = categoriass;
            return View(post);
        }
        [Authorize(Roles = "SuperAdmin, Admin")]
        public IActionResult Actualizar(Post Post)
        {
            Post post = context.Noticias.Where(x => x.PostID == Post.PostID).FirstOrDefault();
            post.Imagen = Post.Imagen;
            post.Resumen = Post.Resumen;
            post.Titulo = Post.Titulo;
            post.Autor = Post.Autor;
            post.Cuerpo = Post.Cuerpo;
            post.Fecha = Post.Fecha;
            post.CategoriaID = Post.CategoriaID;
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
