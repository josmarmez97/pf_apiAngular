using System;
using System.Collections.Generic;

namespace proyecto_final.Models
{
    public partial class Comentarios
    {
        public int id_com { get; set; }
        public string t_com { get; set; }
        public string comentario { get; set; }
        public int id_usuarios { get; set; }

    }
}
