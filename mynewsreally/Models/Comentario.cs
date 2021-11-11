using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mynewsreally.Models
{
    public class Comentario
    {
        public int ComentarioID { get; set; }
        public string Autor { get; set; }
        public string Comentario1 { get; set; }
        public int PostID { get; set; }

        public Post Post { get; set; }
    }
}
