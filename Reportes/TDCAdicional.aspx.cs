using DATOS;
using ENTIDADES;
using ENTIDADES.PichinchaTDCAdicional;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Reportes
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
            }

            //lbl_fecha.Text = DateTime.Now.ToString("yyyyyy-mm-dd");
        }

        private void cargar_clientes()
        {
            
            Reportes_model reportes_m = new Reportes_model();
            List<Cliente> clientes = reportes_m._get_gestion_cliente();
            DataTable g = this.generar_excel(clientes);
            gv_test.DataSource = g;
            gv_test.DataBind();
            if (g.Rows.Count>0)
            {
                lbl_mensaje.Text = "Excel generado";
            }
            else
            {
                lbl_mensaje.Text = "Error";
            }
            
            
        }

        public void tester()
        {
            inConcertSDKnet.CSession session = new inConcertSDKnet.CSession("pruebas@serviportex", "serviportex");
            inConcertSDKnet.APIResult lResult = session.Login("pruebas", "TCADICIONALPICHINCHA", "192.168.100.45", 8082);

            lbl_mensaje.Text = "ID llamada:" + (lResult.OK);


        }

        public DataTable generar_excel(List<Cliente> ls)
        {
            //http://www.3engine.net/wp/2015/10/como-generar-archivos-excel-en-c-con-open-xml/
            bool exito = false;
            var demoTable = new DataTable("Reporte");
            try
            {

                

                #region CREAR CABECERAS
                demoTable.Columns.Add("Fecha_Gestion");
                demoTable.Columns.Add("Usuario");
                demoTable.Columns.Add("Numero_Gestion");
                demoTable.Columns.Add("Tipo_Id");
                demoTable.Columns.Add("Id_adicional");
                demoTable.Columns.Add("Nacionalidad");
                demoTable.Columns.Add("PrimerNombre");
                demoTable.Columns.Add("SegundoNombre");
                demoTable.Columns.Add("PrimerApellido");
                demoTable.Columns.Add("SegundoApellido");
                demoTable.Columns.Add("Nombre_Tarjeta");
                demoTable.Columns.Add("FechaNacimiento");
                demoTable.Columns.Add("Sexo");
                demoTable.Columns.Add("EstadoCivil");
                demoTable.Columns.Add("Parentesco");
                demoTable.Columns.Add("Cupo");
                demoTable.Columns.Add("Cuenta_Titular");
                demoTable.Columns.Add("Id_Titular");
                demoTable.Columns.Add("Producto");
                demoTable.Columns.Add("Nombre_Completo_Titular");
                demoTable.Columns.Add("ProvinciaTrabajo");
                demoTable.Columns.Add("CiudadTrabajo");
                demoTable.Columns.Add("ParroquiaTrabajo");
                demoTable.Columns.Add("CallePrincipalTrabajo");
                demoTable.Columns.Add("NumeracionTrabajo");
                demoTable.Columns.Add("CalleSecundariaTrabajo");
                demoTable.Columns.Add("SectorBarrioTrabajo");
                demoTable.Columns.Add("EdificioTrabajo");
                demoTable.Columns.Add("ReferenciaTrabajo");
                demoTable.Columns.Add("ProvinciaDomicilio");
                demoTable.Columns.Add("CiudadDomicilio");
                demoTable.Columns.Add("ParroquiaDomicilio");
                demoTable.Columns.Add("CallePrincilaDomicilio");
                demoTable.Columns.Add("NumeracionDomicilio");
                demoTable.Columns.Add("CalleSecundariaDomicialio");
                demoTable.Columns.Add("SectorBarrioDomicilio");
                demoTable.Columns.Add("EdificioDomicilio");
                demoTable.Columns.Add("ReferenciaDomicilio");
                demoTable.Columns.Add("LugarEntrega");
                demoTable.Columns.Add("PersonaContacto");
                demoTable.Columns.Add("RangoVicita");
                demoTable.Columns.Add("Celular");
                demoTable.Columns.Add("TelefonoTrabajo");
                demoTable.Columns.Add("TelefonoDomicilio");
                demoTable.Columns.Add("AsistenciaXperta");
                demoTable.Columns.Add("TipoCuota");
                demoTable.Columns.Add("AsistenciaExequial");
                demoTable.Columns.Add("Beneficiario_1_Nombre");
                demoTable.Columns.Add("Beneficiario_1_Apellido");
                demoTable.Columns.Add("Beneficiario_1_Parentesco");
                demoTable.Columns.Add("Beneficiario_2_Nombre");
                demoTable.Columns.Add("Beneficiario__2_Apellido");
                demoTable.Columns.Add("Beneficiario_2_Parentesco");
                demoTable.Columns.Add("Beneficiario_3_Nombre");
                demoTable.Columns.Add("Beneficiario_3_Apellido");
                demoTable.Columns.Add("Beneficiario_3_Parentesco");
                demoTable.Columns.Add("Beneficiario_4_Nombre");
                demoTable.Columns.Add("Beneficiario_4_Apellido");
                demoTable.Columns.Add("Beneficiario_4_Parentesco");
                demoTable.Columns.Add("operador");
                demoTable.Columns.Add("status final");
                demoTable.Columns.Add("intento");

                for (int i = 0; i < 3; i++)
                {
                    demoTable.Columns.Add("Estatus"+i);
                    demoTable.Columns.Add("Sub Estatus"+i);
                    demoTable.Columns.Add("Observación" + i);
                    demoTable.Columns.Add("Fecha" + i);
                    demoTable.Columns.Add("Hora" + i);
                }

                demoTable.Columns.Add("Estatus Final");

                #endregion

                List<String> cl_historial = new List<string>();

                foreach (var cl in ls)
                {
                    Object[] objs = new Object[78];

                    Cliente cl_temp = cl;
                    String estatus_final = cl_temp.Estatus_llamada;
                    if (estatus_final=="CU1")
                    {
                        Console.WriteLine("Un Cu1: ");
                    }

                    if (cl_temp.gestiones != null) {
                        estatus_final = cl_temp.gestiones[cl_temp.gestiones.Count-1].Estatus;
                    }
                    var ls_test = ls.Where(c => c.Estatus_llamada == "CU1" || c.Estatus_llamada == "CU2" || c.Estatus_llamada == "CU3");
                    if (cl_temp.gestiones == null)
                        continue;

                    if(cl_historial.Contains(cl.Identificacion))
                        break;

                    foreach (var item in cl_temp.gestiones.OrderByDescending(x=>x.Fecha_Gestion))
                    {
                        if ((cl_historial.Contains(item.Id_Titular) && (item.Estatus != "CU1")) && (item.Estatus != "CU3"))
                            break;

                        objs[0] = item.Fecha_Gestion + "";
                        objs[1] = item.Usuario + "";
                        objs[2] = item.Numero_Gestion + "";
                        objs[3] = item.Tipo_Id + "";
                        objs[4] = item.Id_adicional + "";
                        objs[5] = item.Nacionalidad + "";
                        objs[6] = item.PrimerNombre + "";
                        objs[7] = item.SegundoNombre + "";
                        objs[8] = item.PrimerApellido + "";
                        objs[9] = item.SegundoApellido + "";
                        objs[10] = item.Nombre_Tarjeta + "";
                        objs[11] = item.FechaNacimiento + "";
                        objs[12] = item.Sexo + "";
                        objs[13] = item.EstadoCivil + "";
                        objs[14] = item.Parentesco + "";
                        objs[15] = item.Cupo + "";
                        objs[16] = item.Cuenta_Titular + "";
                        objs[17] = item.Id_Titular + "";
                        objs[18] = item.Producto + "";
                        objs[19] = item.Nombre_Completo_Titular + "";
                        objs[20] = item.ProvinciaTrabajo + "";
                        objs[21] = item.CiudadTrabajo + "";
                        objs[22] = item.ParroquiaTrabajo + "";
                        objs[23] = item.CallePrincipalTrabajo + "";
                        objs[24] = item.NumeracionTrabajo + "";
                        objs[25] = item.CalleSecundariaTrabajo + "";
                        objs[26] = item.SectorBarrioTrabajo + "";
                        objs[27] = item.EdificioTrabajo + "";
                        objs[28] = item.ReferenciaTrabajo + "";
                        objs[29] = item.ProvinciaDomicilio + "";
                        objs[30] = item.CiudadDomicilio + "";
                        objs[31] = item.ParroquiaDomicilio + "";
                        objs[32] = item.CallePrincilaDomicilio + "";
                        objs[33] = item.NumeracionDomicilio + "";
                        objs[34] = item.CalleSecundariaDomicialio + "";
                        objs[35] = item.SectorBarrioDomicilio + "";
                        objs[36] = item.EdificioDomicilio + "";
                        objs[37] = item.ReferenciaDomicilio + "";
                        objs[38] = item.LugarEntrega + "";
                        objs[39] = item.PersonaContacto + "";
                        objs[40] = item.RangoVicita + "";
                        objs[41] = item.Celular + "";
                        objs[42] = item.TelefonoTrabajo + "";
                        objs[43] = item.TelefonoDomicilio + "";
                        objs[44] = item.AsistenciaXperta + "";
                        objs[45] = item.TipoCuota + "";
                        objs[46] = item.AsistenciaExequial + "";
                        objs[47] = item.Beneficiario_1_Nombre + "";
                        objs[48] = item.Beneficiario_1_Apellido + "";
                        objs[49] = item.Beneficiario_1_Parentesco + "";
                        objs[50] = item.Beneficiario_2_Nombre + "";
                        objs[51] = item.Beneficiario__2_Apellido + "";
                        objs[52] = item.Beneficiario_2_Parentesco + "";
                        objs[53] = item.Beneficiario_3_Nombre + "";
                        objs[54] = item.Beneficiario_3_Apellido + "";
                        objs[55] = item.Beneficiario_3_Parentesco + "";
                        objs[56] = item.Beneficiario_4_Nombre + "";
                        objs[57] = item.Beneficiario_4_Apellido + "";
                        objs[58] = item.Beneficiario_4_Parentesco + "";
                        objs[59] = item.operador + "";
                        objs[60] = item.status_final + "";

                        /* CUENTA LA CANTIDAD DE LLAMADAS QUE SE HIZO POR CLIENTE */
                        objs[61] = item.intento + "";

                        //if (cl_historial.Contains(item.Id_Titular))
                        //    break;

                        int i_helper = 0;
                        bool existe_venta = false;

                        if (cl_temp.gestiones.Count > 0  && (!existe_venta))
                        {
                            //objs[62] = item.Estatus + "";
                            //objs[63] = item.Producto + "";
                            //objs[64] = item.Observaciones + "";
                            //DateTime fech = DateTime.Parse(item.Fecha_Gestion + "");
                            //objs[65] = fech.ToString("yyyy-mm-dd") + "";
                            //objs[66] = fech.ToString("HH:mm:ss") + "";

                            objs[62] = cl_temp.gestiones[0].Estatus + "";
                            objs[63] = cl_temp.gestiones[0].Producto + "";
                            objs[64] = cl_temp.gestiones[0].Observaciones + "";
                            DateTime fech1 = DateTime.Parse(cl_temp.gestiones[0].Fecha_Gestion + "");
                            objs[65] = fech1.ToString("yyyy-mm-dd") + "";
                            objs[66] = fech1.ToString("HH:mm:ss") + "";
                            existe_venta = (cl_temp.gestiones[0].Estatus == "CU1");
                            i_helper++;
                        }
                        else
                        {
                            objs[62] = "";
                            objs[63] = "";
                            objs[64] = "";
                            objs[65] = "";
                            objs[66] = "";
                        }

                       
                        int conteo = (cl_temp.gestiones.Count(x=>x.Estatus=="CU1" || x.Estatus=="CU3"));




                        if (cl_temp.gestiones.Count > 1 && (!existe_venta))
                        {
                            objs[67] = cl_temp.gestiones[1].Estatus + "";
                            objs[68] = cl_temp.gestiones[1].Producto + "";
                            objs[69] = cl_temp.gestiones[1].Observaciones + "";
                            DateTime fech1 = DateTime.Parse(cl_temp.gestiones[1].Fecha_Gestion + "");
                            objs[70] = fech1.ToString("yyyy-mm-dd") + "";
                            objs[71] = fech1.ToString("HH:mm:ss") + "";
                            existe_venta = (cl_temp.gestiones[1].Estatus == "CU1");
                            i_helper++;
                        }
                        else
                        {
                            objs[67] = "";
                            objs[68] = "";
                            objs[69] = "";
                            objs[70] = "";
                            objs[71] = "";
                        }

                        if (cl_temp.gestiones.Count > 2 && (!existe_venta))
                        {
                            objs[72] = cl_temp.gestiones[2].Estatus + "";
                            objs[73] = cl_temp.gestiones[2].Producto + "";
                            objs[74] = cl_temp.gestiones[2].Observaciones + "";
                            DateTime fech2 = DateTime.Parse(cl_temp.gestiones[2].Fecha_Gestion + "");
                            objs[75] = fech2.ToString("yyyy-mm-dd") + "";
                            objs[76] = fech2.ToString("HH:mm:ss") + "";
                            existe_venta = (cl_temp.gestiones[2].Estatus == "CU1");
                            i_helper++;
                        }
                        else
                        {
                            objs[72] = "";
                            objs[73] = "";
                            objs[74] = "";
                            objs[75] = "";
                            objs[76] = "";
                        }

                        /* CUENTA LA CANTIDAD DE LLAMADAS QUE SE HIZO POR CLIENTE */
                        objs[61] = i_helper + ""; /* ACTUALIZA LOS INTENTOS */

                        objs[77] = estatus_final;
                        cl_historial.Add(item.Id_Titular);
                        

                        demoTable.Rows.Add(objs);
                    }
                }
                DateTime f = DateTime.Now;
                //String fech_sel = f.Year + "" + f.Month + "" + f.Day + "" + f.Hour + "" + f.Minute + "" + f.Second + "" + f.Millisecond;
                //SaveExcel.BuildExcel(demoTable, "C:/Reportes generados/Reporte_" + fech_sel + ".xlsx");
                exito = true;

            }
            catch (Exception)
            {

            }

            return demoTable;
        }


        protected void btn_generar_Reporte_Click(object sender, EventArgs e)
        {
            cargar_clientes();
            ExportGridView1();
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
            gv_test.Parent.Controls.Add(frm);
            frm.Attributes["runat"] = "server";
            frm.Controls.Add(gv_test);

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