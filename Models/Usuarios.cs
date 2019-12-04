using System;
using System.Collections.Generic;

namespace proyecto_final.Models
{
    public partial class Usuarios
    {
        

        public int id_usuario { get; set; }
        public string userid { get; set; }
        public string pass { get; set; }
        public int id_rol { get; set; }
    }
}
