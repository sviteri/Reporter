using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTIDADES
{
    public class Usuario
    {
        public int id { get; set; }
        public int id_rol { get; set; }
        public String nombre { get; set; }
        public String seudonimo { get; set; }
        public String clave { get; set; }
        public bool estado { get; set; }
    }
}
