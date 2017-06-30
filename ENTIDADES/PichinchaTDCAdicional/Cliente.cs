using ENTIDADES.PichinchaTDCAdicional;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTIDADES
{
    public class Cliente
    {
        public String Cuenta { get; set; }
        public String Identificacion { get; set; }
        public String Nombres { get; set; }
        public String Apellidos { get; set; }
        public String Email { get; set; }
        public String Producto { get; set; }
        public String Familia { get; set; }
        public Decimal Cupo { get; set; }
        public Decimal Cupo_disponible { get; set; }
        public String Direccion { get; set; }
        public String Telefono_domicilio1 { get; set; }
        public String Telefono_domicilio2 { get; set; }
        public String Telefono_trabajo { get; set; }
        public String Telefono1 { get; set; }
        public String Telefono2 { get; set; }
        public String Telefono3 { get; set; }
        public String Celular { get; set; }
        public String Ciudad { get; set; }
        public String Genero { get; set; }
        public String Estado_civil { get; set; }
        public String Estatus_llamada { get; set; }
        public String SubEstatus_llamada { get; set; }
        public String Estado_cuenta_electro { get; set; }
        public String Observaciones { get; set; }
        public String Agente { get; set; }
        public String Celular2 { get; set; }
        public String Base { get; set; }
        public DateTime Fecha_creacion { get; set; }
        public DateTime Fecha_rellamar { get; set; }
        public String Hora_rellamar { get; set; }
        public String Parentesco { get; set; }
        public bool Activo { get; set; }

        public List<GestionesCliente> gestiones { get; set;  }

    }
}
