using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace mynewsreally.Models
{
    public class Post
    {
        [DataType(DataType.MultilineText)]
        public int PostID { get; set; }
        public string Imagen { get; set; }
        [StringLength(70)]
        public string Titulo { get; set; }
        [DataType(DataType.MultilineText)]
        public string Resumen { get; set; }
        public string Autor { get; set; }
        [DataType(DataType.MultilineText)]
        public string Cuerpo { get; set; }
        public DateTime Fecha { get; set; }
        public List<Comentario> Comentarios { get; set; }

        public int CategoriaID { get; set; }

        public Categoria Categoria { get; set; }
    }
}
