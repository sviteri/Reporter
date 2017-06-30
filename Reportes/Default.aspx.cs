using DATOS;
using ENTIDADES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Reportes
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void Ingreso_usuarios() {
            String usuario = txt_nick.Value;
            String clave = txt_clave.Value;
            Administracion_model m = new Administracion_model();
            

            Usuario u = m.get_usuario_by_credenciales(usuario, clave);
            if (u!=null && u.id>0 )
            {
                Session["usuario"] = u;
                Response.Redirect("~/TDCAdicional.aspx");
            }
            else
            {
                div_error.Visible = true;
                lbl_mensaje.Text = "Ingreso No Autorizado";
            }
        }

        protected void btn_ingreso_Click(object sender, EventArgs e)
        {
            Ingreso_usuarios();
        }
    }
}