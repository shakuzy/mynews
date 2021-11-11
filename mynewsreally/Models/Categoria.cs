using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mynewsreally.Models
{
    public class Categoria
    {
        public int CategoriaID { get; set; }
        public string Nombre { get; set; }
        public List<Post> Noticias { get; set; }
    }
}
