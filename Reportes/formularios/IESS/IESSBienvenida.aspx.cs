using DATOS.IESS;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Reportes.formularios.IESS
{
    public partial class IESSBienvenida : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               
            }
        }

        public void cargar_tabla(String fecha)
        {
            IESS_ReportesModel mo = new IESS_ReportesModel();
            var datos = mo._ejecutar_consulta(fecha);
            gv_prueba.DataSource = datos;
            gv_prueba.DataBind();
        }

      

        private void ExportGridView1()
        {
            DateTime f = DateTime.Now;
            String fech_sel = f.Year + "" + f.Month + "" + f.Day + "" + f.Hour + "" + f.Minute + "" + f.Second + "" + f.Millisecond;
            string attachment = "attachment; filename=Rep_" + fech_sel + ".xls";
            Response.ClearContent();
            Response.AddHeader("content-disposition", attachment);
            Response.ContentType = "application/ms-excel";
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);

            // Create a form to contain the grid
            HtmlForm frm = new HtmlForm();
            gv_prueba.Parent.Controls.Add(frm);
            frm.Attributes["runat"] = "server";
            frm.Controls.Add(gv_prueba);

            frm.RenderControl(htw);
            //GridView1.RenderControl(htw);
            Response.Write(sw.ToString());
            Response.End();



        }
        private void PrepareGridViewForExport(Control gv)
        {
            LinkButton lb = new LinkButton();
            Literal l = new Literal();
            string name = String.Empty;
            for (int i = 0; i < gv.Controls.Count; i++)
            {
                if (gv.Controls[i].GetType() == typeof(LinkButton))
                {
                    l.Text = (gv.Controls[i] as LinkButton).Text;
                    gv.Controls.Remove(gv.Controls[i]);
                    gv.Controls.AddAt(i, l);
                }
                else if (gv.Controls[i].GetType() == typeof(DropDownList))
                {
                    l.Text = (gv.Controls[i] as DropDownList).SelectedItem.Text;
                    gv.Controls.Remove(gv.Controls[i]);
                    gv.Controls.AddAt(i, l);
                }
                else if (gv.Controls[i].GetType() == typeof(CheckBox))
                {
                    l.Text = (gv.Controls[i] as CheckBox).Checked ? "True" : "False";
                    gv.Controls.Remove(gv.Controls[i]);
                    gv.Controls.AddAt(i, l);
                }
                if (gv.Controls[i].HasControls())
                {
                    PrepareGridViewForExport(gv.Controls[i]);
                }
            }
        }

        protected void Unnamed_Click(object sender, EventArgs e)
        {
            cargar_tabla(txt_fecha.Text);
            ExportGridView1();
        }
    }
}