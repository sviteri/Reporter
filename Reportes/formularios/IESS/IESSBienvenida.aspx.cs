using DATOS.IESS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Reportes.formularios.IESS
{
    public partial class IESSBienvenida : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargar_tabla();
            }
        }

        public void cargar_tabla()
        {
            IESS_ReportesModel mo = new IESS_ReportesModel();
            gv_prueba.DataSource= mo._get_gestion_cliente();
            gv_prueba.DataBind();
        }
    }
}