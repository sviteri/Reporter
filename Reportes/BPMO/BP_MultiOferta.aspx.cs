using DATOS;
using ENTIDADES.MultiOferta;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Reportes.BPMO
{
    public partial class BP_MultiOferta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
            }
        }

        protected void cargar_clientes()
        {
            BPMultiOferta_model model = new BPMultiOferta_model();
            String st_limit = txt_limite.Text+"";
            Int64 limit = 0;
            if (st_limit.Length <= 0)
            {
                limit = 0;
            }
            else
            {
                limit = Convert.ToInt64(txt_limite.Text);
            }
            List<Cliente> clientes = model.get_clientes("", limit);
            DataTable dt = model.generar_excel_multioferta(clientes);
            gv_clientes.DataSource = dt;
            gv_clientes.DataBind();

            ExportGridView1();
        }

        protected void btn_generar_Click(object sender, EventArgs e)
        {
            cargar_clientes();
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
            gv_clientes.Parent.Controls.Add(frm);
            frm.Attributes["runat"] = "server";
            frm.Controls.Add(gv_clientes);

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
    }
}