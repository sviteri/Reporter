using ENTIDADES.BP_MultiOferta;
using ENTIDADES.MultiOferta;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATOS
{
    public class BPMultiOferta_model
    {
        Conexion conex = new Conexion("BancoPichinchaMO");

        public List<Cliente> get_clientes(String agente, Int64 limit)
        {
            List<Cliente> lista = new List<Cliente>();
           
            SqlConnection myConnection = conex.Conectar();
            try
            {
                myConnection.Open();
                String sql_extra = "";
                if (limit>0)
                {
                    sql_extra = "TOP "+limit;
                }
                String sql = "SELECT " + sql_extra + " c.Cedula FROM Clientes c WHERE c.Cedula in (SELECT l.Cedula FROM Llamadas l WHERE c.Cedula=l.Cedula);";
                SqlCommand cm = new SqlCommand(sql, myConnection);
                SqlDataReader r = cm.ExecuteReader();

                #region CONTRUCCION DEL OBJETO
                while (r.Read())
                {
                    Cliente cl = new Cliente
                    {
                        Cedula = r[0].ToString()
                    };
                    lista.Add(cl);
                }
                #endregion

                r.Close(); /* CERRAR EL RESULT SET PRIMERO*/

                #region Consulta Historial Por cliente
                foreach (var c in lista)
                {
                    String sql2 = "SELECT TOP 100 g.ContactAddress,g.LastAgent,g.ResultLevel1, "+
                    "g.ResultLevel2,g.ResultLevel3,g.TmStmp,g.CampaignId, "+
                    "g.Observaciones,c.Cedula,c.Nombre, "+
                    "g.Telefono1,g.Telefono2,'Telefono Adicional' as Telefono_add, "+
                    "g.ProductoVenta,g.AsistenciaXPERTA,g.AsistenciaEXEQUIAL, "+
                    "g.AE_N1,g.AE_Nombre_1,g.AE_Edad_1,g.AE_Parentesco_1, "+
                    "g.AE_N2,g.AE_Nombre_2,g.AE_Edad_2,g.AE_Parentesco_2, "+ 
                    "g.AE_N3,g.AE_Nombre_3,g.AE_Edad_3,g.AE_Parentesco_3, "+
                    "g.AE_N4,g.AE_Nombre_4,g.AE_Edad_4,g.AE_Parentesco_4, "+
                    "g.RegionAgencia,g.ProvinciaAgencia,g.ZonaAgencia, "+
                    "g.Agencia,g.DireccionAgencia,g.TipoCliente,g.FechaDesembolso, "+
                    "g.FechaAgendamiento,g.ResultadoSeguimiento,g.DataGestion0, "+
                    "g.DataGestion1,g.DataGestion2,'SN' as Observaciones_2, "+
                    "'' AS Tajeta,'' as Cupotarjeta, "+
                    "m.TipoDocumento,m.Documento,m.PrimerNombre,m.SegundoNombre,m.PrimerApellido, "+
                    "m.SegundoApellido,m.Nacionalidad,m.PaisNacimiento, "+
                    "m.ProvinciaNacimiento,m.CiudadNacimeinto,m.FechaNacimiento, "+
                    "m.Genero,m.EstadoCivil,m.Celular,m.EmailPersonal,m.ProvinciaDomicilio, "+
                    "m.CiudadDomicilio,m.CantonDomicilio,m.ParroquiaDomicilio, "+
                    "m.CallePrincipalDomicilio,m.NumeracionDomicilio,m.CalleSecundariaDomicialio, "+
                    "m.SectorBarrioDomicilio,m.ReferenciaDomicilio,m.TelefonoDomicilio, "+
                    "m.SituacionLaboral,m.TipoVivienda,m.ObligadoContabilidad, "+
                    "m.NombreNegocio,m.FechaIniNegocio,m.ActividadEconomica,m.VentasHMensuales, "+
                    "m.CostoVentas,m.GastosOperativos,m.NombreEmpresa,m.Contrato, "+
                    "m.Cargo,m.FechaIniTrabAct,m.Sueldo,m.GastosFamilia,m.ProvinciaTrabajo, "+
                    "m.CiudadTrabajo,m.CantonTrabajo,m.ParroquiaTrabajo,m.CallePrincipalTrabajo,m.NumeracionTrabajo, "+
                    "m.CalleSecundariaTrabajo, "+
                    "m.SectorBarrioTrabajo,m.ReferenciaTrabajo,m.TelefonoTrabajo, "+
                    "m.EmailTrabajo,m.PersonaReferencia,m.PaisReferencia,m.ProvinciaReferencia,m.CiudadReferencia, " +
                    "m.TelefonoReferencia, "+
                    "m.Parentesco,m.LugarEntrega,m.PersonaContacto,m.TelefonoContacto, "+
                    "m.EquipoFutbol,m.HorarioEntrega FROM Clientes c JOIN Gestiones g  "+
                    "ON c.Cedula=g.Cedula left JOIN  "+
                    "GestionesMOTC m ON g.Cedula=m.Documento WHERE g.Cedula='" + c.Cedula + "' ;";
                    SqlCommand cm2 = new SqlCommand(sql2, myConnection);
                    SqlDataReader r2 = cm2.ExecuteReader();
                    List<GestionMO_report> ls_rep = new List<GestionMO_report>();
                    while (r2.Read())
                    {
                        GestionMO_report rep = new GestionMO_report();
                        rep.ContactAddress = r2[0].ToString();
                        rep.LastAgent = r2[1].ToString();
                        rep.ResultLevel1 = r2[2].ToString();
                        rep.ResultLevel2 = r2[3].ToString();
                        rep.ResultLevel3 = r2[4].ToString();
                        rep.TmStmp = r2[5].ToString();
                        rep.CampaignId = r2[6].ToString();
                        rep.Observaciones = r2[7].ToString();
                        rep.Cedula = r2[8].ToString();
                        rep.Nombre = r2[9].ToString();
                        rep.Telefono1 = r2[10].ToString();
                        rep.Telefono2 = r2[11].ToString();
                        rep.Telefono_add = r2[12].ToString();
                        rep.ProductoVenta = r2[13].ToString();
                        rep.AsistenciaXPERTA = r2[14].ToString();
                        rep.AsistenciaEXEQUIAL = r2[15].ToString();
                        rep.AE_N1 = r2[16].ToString();
                        rep.AE_Nombre_1 = r2[17].ToString();
                        rep.AE_Edad_1 = r2[18].ToString();
                        rep.AE_Parentesco_1 = r2[19].ToString();
                        rep.AE_N2 = r2[20].ToString();
                        rep.AE_Nombre_2 = r2[21].ToString();
                        rep.AE_Edad_2 = r2[22].ToString();
                        rep.AE_Parentesco_2 = r2[23].ToString();
                        rep.AE_N3 = r2[24].ToString();
                        rep.AE_Nombre_3 = r2[25].ToString();
                        rep.AE_Edad_3 = r2[26].ToString();
                        rep.AE_Parentesco_3 = r2[27].ToString();
                        rep.AE_N4 = r2[28].ToString();
                        rep.AE_Nombre_4 = r2[29].ToString();
                        rep.AE_Edad_4 = r2[30].ToString();
                        rep.AE_Parentesco_4 = r2[31].ToString();
                        rep.RegionAgencia = r2[32].ToString();
                        rep.ProvinciaAgencia = r2[33].ToString();
                        rep.ZonaAgencia = r2[34].ToString();
                        rep.Agencia = r2[35].ToString();
                        rep.DireccionAgencia = r2[36].ToString();
                        rep.TipoCliente = r2[37].ToString();
                        rep.FechaDesembolso = r2[38].ToString();
                        rep.FechaAgendamiento = r2[39].ToString();
                        rep.ResultadoSeguimiento = r2[40].ToString();
                        rep.DataGestion0 = r2[41].ToString();
                        rep.DataGestion1 = r2[42].ToString();
                        rep.DataGestion2 = r2[43].ToString();
                        rep.Observaciones_2 = r2[44].ToString();
                        rep.Tajeta = r2[45].ToString();
                        rep.Cupotarjeta = r2[46].ToString();
                        rep.TipoDocumento = r2[47].ToString();
                        rep.Documento = r2[48].ToString();
                        rep.PrimerNombre = r2[49].ToString();
                        rep.SegundoNombre = r2[50].ToString();
                        rep.PrimerApellido = r2[51].ToString();
                        rep.SegundoApellido = r2[52].ToString();
                        rep.Nacionalidad = r2[53].ToString();
                        rep.PaisNacimiento = r2[54].ToString();
                        rep.ProvinciaNacimiento = r2[55].ToString();
                        rep.CiudadNacimeinto = r2[56].ToString();
                        rep.FechaNacimiento = r2[57].ToString();
                        rep.Genero = r2[58].ToString();
                        rep.EstadoCivil = r2[59].ToString();
                        rep.Celular = r2[60].ToString();
                        rep.EmailPersonal = r2[61].ToString();
                        rep.ProvinciaDomicilio = r2[62].ToString();
                        rep.CiudadDomicilio = r2[63].ToString();
                        rep.CantonDomicilio = r2[64].ToString();
                        rep.ParroquiaDomicilio = r2[65].ToString();
                        rep.CallePrincipalDomicilio = r2[66].ToString();
                        rep.NumeracionDomicilio = r2[67].ToString();
                        rep.CalleSecundariaDomicialio = r2[68].ToString();
                        rep.SectorBarrioDomicilio = r2[69].ToString();
                        rep.ReferenciaDomicilio = r2[70].ToString();
                        rep.TelefonoDomicilio = r2[71].ToString();
                        rep.SituacionLaboral = r2[72].ToString();
                        rep.TipoVivienda = r2[73].ToString();
                        rep.ObligadoContabilidad = r2[74].ToString();
                        rep.NombreNegocio = r2[75].ToString();
                        rep.FechaIniNegocio = r2[76].ToString();
                        rep.ActividadEconomica = r2[77].ToString();
                        rep.VentasHMensuales = r2[78].ToString();
                        rep.CostoVentas = r2[79].ToString();
                        rep.GastosOperativos = r2[80].ToString();
                        rep.NombreEmpresa = r2[81].ToString();
                        rep.Contrato = r2[82].ToString();
                        rep.Cargo = r2[83].ToString();
                        rep.FechaIniTrabAct = r2[84].ToString();
                        rep.Sueldo = r2[85].ToString();
                        rep.GastosFamilia = r2[86].ToString();
                        rep.ProvinciaTrabajo = r2[87].ToString();
                        rep.CiudadTrabajo = r2[88].ToString();
                        rep.CantonTrabajo = r2[89].ToString();
                        rep.ParroquiaTrabajo = r2[90].ToString();
                        rep.CallePrincipalTrabajo = r2[91].ToString();
                        rep.NumeracionTrabajo = r2[92].ToString();
                        rep.CalleSecundariaTrabajo = r2[93].ToString();
                        rep.SectorBarrioTrabajo = r2[94].ToString();
                        rep.ReferenciaTrabajo = r2[95].ToString();
                        rep.TelefonoTrabajo = r2[96].ToString();
                        rep.EmailTrabajo = r2[97].ToString();
                        rep.PersonaReferencia = r2[98].ToString();
                        rep.PaisReferencia = r2[99].ToString();
                        rep.ProvinciaReferencia = r2[100].ToString();
                        rep.CiudadReferencia = r2[101].ToString();
                        rep.TelefonoReferencia = r2[102].ToString();
                        rep.Parentesco = r2[103].ToString();
                        rep.LugarEntrega = r2[104].ToString();
                        rep.PersonaContacto = r2[105].ToString();
                        rep.TelefonoContacto = r2[106].ToString();
                        rep.EquipoFutbol = r2[107].ToString();
                        rep.HorarioEntrega = r2[108].ToString();
                        rep.Fecha1 = String.Empty;
                        rep.hora1 = String.Empty;
                        rep.estatus1 = String.Empty;
                        rep.Subestatus1 = String.Empty;
                        rep.Fecha2 = String.Empty;
                        rep.hora2 = String.Empty;
                        rep.estatus2 = String.Empty;
                        rep.Subestatus2 = String.Empty;
                        rep.Fecha3 = String.Empty;
                        rep.hora3 = String.Empty;
                        rep.estatus3 = String.Empty;
                        rep.Subestatus3 = String.Empty;
                        rep.Fecha4 = String.Empty;
                        rep.hora4 = String.Empty;
                        rep.estatus4 = String.Empty;
                        rep.Subestatus4 = String.Empty;
                        ls_rep.Add(rep);
                    }

                    c.reporte = ls_rep;
                    r2.Close();
                }

                #endregion
            }
            catch(Exception ex){

            }
            finally
            {
                myConnection.Close();
            }
            return lista;
            
        }

        public DataTable generar_excel_multioferta(List<Cliente> ls)
        {
            //http://www.3engine.net/wp/2015/10/como-generar-archivos-excel-en-c-con-open-xml/
            bool exito = false;
            var demoTable = new DataTable("ReporteMultiOferta");
            try
            {
                #region CREAR CABECERAS
                demoTable.Columns.Add("ContactAddress");
                demoTable.Columns.Add("LastAgent");
                demoTable.Columns.Add("ResultLevel1");
                demoTable.Columns.Add("ResultLevel2");
                demoTable.Columns.Add("ResultLevel3");
                demoTable.Columns.Add("TmStmp");
                demoTable.Columns.Add("CampaignId");
                demoTable.Columns.Add("Observaciones");
                demoTable.Columns.Add("Cedula");
                demoTable.Columns.Add("Nombre");
                demoTable.Columns.Add("Telefono1");
                demoTable.Columns.Add("Telefono2");
                demoTable.Columns.Add("Telefono_add");
                demoTable.Columns.Add("ProductoVenta");
                demoTable.Columns.Add("AsistenciaXPERTA");
                demoTable.Columns.Add("AsistenciaEXEQUIAL");
                demoTable.Columns.Add("AE_N1");
                demoTable.Columns.Add("AE_Nombre_1");
                demoTable.Columns.Add("AE_Edad_1");
                demoTable.Columns.Add("AE_Parentesco_1");
                demoTable.Columns.Add("AE_N2");
                demoTable.Columns.Add("AE_Nombre_2");
                demoTable.Columns.Add("AE_Edad_2");
                demoTable.Columns.Add("AE_Parentesco_2");
                demoTable.Columns.Add("AE_N3");
                demoTable.Columns.Add("AE_Nombre_3");
                demoTable.Columns.Add("AE_Edad_3");
                demoTable.Columns.Add("AE_Parentesco_3");
                demoTable.Columns.Add("AE_N4");
                demoTable.Columns.Add("AE_Nombre_4");
                demoTable.Columns.Add("AE_Edad_4");
                demoTable.Columns.Add("AE_Parentesco_4");
                demoTable.Columns.Add("RegionAgencia");
                demoTable.Columns.Add("ProvinciaAgencia");
                demoTable.Columns.Add("ZonaAgencia");
                demoTable.Columns.Add("Agencia");
                demoTable.Columns.Add("DireccionAgencia");
                demoTable.Columns.Add("TipoCliente");
                demoTable.Columns.Add("FechaDesembolso");
                demoTable.Columns.Add("FechaAgendamiento");
                demoTable.Columns.Add("ResultadoSeguimiento");
                demoTable.Columns.Add("DataGestion0");
                demoTable.Columns.Add("DataGestion1");
                demoTable.Columns.Add("DataGestion2");
                demoTable.Columns.Add("Observaciones_2");
                demoTable.Columns.Add("Tajeta");
                demoTable.Columns.Add("Cupotarjeta");
                demoTable.Columns.Add("TipoDocumento");
                demoTable.Columns.Add("Documento");
                demoTable.Columns.Add("PrimerNombre");
                demoTable.Columns.Add("SegundoNombre");
                demoTable.Columns.Add("PrimerApellido");
                demoTable.Columns.Add("SegundoApellido");
                demoTable.Columns.Add("Nacionalidad");
                demoTable.Columns.Add("PaisNacimiento");
                demoTable.Columns.Add("ProvinciaNacimiento");
                demoTable.Columns.Add("CiudadNacimeinto");
                demoTable.Columns.Add("FechaNacimiento");
                demoTable.Columns.Add("Genero");
                demoTable.Columns.Add("EstadoCivil");
                demoTable.Columns.Add("Celular");
                demoTable.Columns.Add("EmailPersonal");
                demoTable.Columns.Add("ProvinciaDomicilio");
                demoTable.Columns.Add("CiudadDomicilio");
                demoTable.Columns.Add("CantonDomicilio");
                demoTable.Columns.Add("ParroquiaDomicilio");
                demoTable.Columns.Add("CallePrincipalDomicilio");
                demoTable.Columns.Add("NumeracionDomicilio");
                demoTable.Columns.Add("CalleSecundariaDomicialio");
                demoTable.Columns.Add("SectorBarrioDomicilio");
                demoTable.Columns.Add("ReferenciaDomicilio");
                demoTable.Columns.Add("TelefonoDomicilio");
                demoTable.Columns.Add("SituacionLaboral");
                demoTable.Columns.Add("TipoVivienda");
                demoTable.Columns.Add("ObligadoContabilidad");
                demoTable.Columns.Add("NombreNegocio");
                demoTable.Columns.Add("FechaIniNegocio");
                demoTable.Columns.Add("ActividadEconomica");
                demoTable.Columns.Add("VentasHMensuales");
                demoTable.Columns.Add("CostoVentas");
                demoTable.Columns.Add("GastosOperativos");
                demoTable.Columns.Add("NombreEmpresa");
                demoTable.Columns.Add("Contrato");
                demoTable.Columns.Add("Cargo");
                demoTable.Columns.Add("FechaIniTrabAct");
                demoTable.Columns.Add("Sueldo");
                demoTable.Columns.Add("GastosFamilia");
                demoTable.Columns.Add("ProvinciaTrabajo");
                demoTable.Columns.Add("CiudadTrabajo");
                demoTable.Columns.Add("CantonTrabajo");
                demoTable.Columns.Add("ParroquiaTrabajo");
                demoTable.Columns.Add("CallePrincipalTrabajo");
                demoTable.Columns.Add("NumeracionTrabajo");
                demoTable.Columns.Add("CalleSecundariaTrabajo");
                demoTable.Columns.Add("SectorBarrioTrabajo");
                demoTable.Columns.Add("ReferenciaTrabajo");
                demoTable.Columns.Add("TelefonoTrabajo");
                demoTable.Columns.Add("EmailTrabajo");
                demoTable.Columns.Add("PersonaReferencia");
                demoTable.Columns.Add("PaisReferencia");
                demoTable.Columns.Add("ProvinciaReferencia");
                demoTable.Columns.Add("CiudadReferencia");
                demoTable.Columns.Add("TelefonoReferencia");
                demoTable.Columns.Add("Parentesco");
                demoTable.Columns.Add("LugarEntrega");
                demoTable.Columns.Add("PersonaContacto");
                demoTable.Columns.Add("TelefonoContacto");
                demoTable.Columns.Add("EquipoFutbol");
                demoTable.Columns.Add("HorarioEntrega");
                demoTable.Columns.Add("Fecha1");
                demoTable.Columns.Add("hora1");
                demoTable.Columns.Add("estatus1");
                demoTable.Columns.Add("Subestatus1");
                demoTable.Columns.Add("Fecha2");
                demoTable.Columns.Add("hora2");
                demoTable.Columns.Add("estatus2");
                demoTable.Columns.Add("Subestatus2");
                demoTable.Columns.Add("Fecha3");
                demoTable.Columns.Add("hora3");
                demoTable.Columns.Add("estatus3");
                demoTable.Columns.Add("Subestatus3");
                demoTable.Columns.Add("Fecha4");
                demoTable.Columns.Add("hora4");
                demoTable.Columns.Add("estatus4");
                demoTable.Columns.Add("Subestatus4");

                demoTable.Columns.Add("Estatus Final");
                demoTable.Columns.Add("Intentos");

                #endregion

                List<String> cl_historial = new List<string>();

                foreach (var cl in ls)
                {
                    Object[] objs = new Object[127];

                    Cliente cl_temp = cl;
                    String estatus_final = "";
                    if (estatus_final.Contains("CU1"))
                    {
                        Console.WriteLine("Un Cu1: ");
                    }

                    if (cl_temp.reporte != null && cl_temp.reporte.Count>0)
                    {
                        estatus_final = cl_temp.reporte[cl_temp.reporte.Count - 1].ResultLevel1;
                    }
                    
                    if (cl_temp.reporte == null)
                        continue;

                    if (cl_historial.Contains(cl.Cedula))
                        break;

                    foreach (var item in cl_temp.reporte.OrderByDescending(x => x.TmStmp))
                    {
                        if ((cl_historial.Contains(item.Cedula) && (!item.ResultLevel1.Contains("CU1")) && (!item.ResultLevel1.Contains("CU3"))))
                            break;

                        objs[0] = item.ContactAddress + String.Empty;
                        objs[1] = item.LastAgent + String.Empty;
                        objs[2] = item.ResultLevel1 + String.Empty;
                        objs[3] = item.ResultLevel2 + String.Empty;
                        objs[4] = item.ResultLevel3 + String.Empty;
                        objs[5] = item.TmStmp + String.Empty;
                        objs[6] = item.CampaignId + String.Empty;
                        objs[7] = item.Observaciones + String.Empty;
                        objs[8] = item.Cedula + String.Empty;
                        objs[9] = item.Nombre + String.Empty;
                        objs[10] = item.Telefono1 + String.Empty;
                        objs[11] = item.Telefono2 + String.Empty;
                        objs[12] = item.Telefono_add + String.Empty;
                        objs[13] = item.ProductoVenta + String.Empty;
                        objs[14] = item.AsistenciaXPERTA + String.Empty;
                        objs[15] = item.AsistenciaEXEQUIAL + String.Empty;
                        objs[16] = item.AE_N1 + String.Empty;
                        objs[17] = item.AE_Nombre_1 + String.Empty;
                        objs[18] = item.AE_Edad_1 + String.Empty;
                        objs[19] = item.AE_Parentesco_1 + String.Empty;
                        objs[20] = item.AE_N2 + String.Empty;
                        objs[21] = item.AE_Nombre_2 + String.Empty;
                        objs[22] = item.AE_Edad_2 + String.Empty;
                        objs[23] = item.AE_Parentesco_2 + String.Empty;
                        objs[24] = item.AE_N3 + String.Empty;
                        objs[25] = item.AE_Nombre_3 + String.Empty;
                        objs[26] = item.AE_Edad_3 + String.Empty;
                        objs[27] = item.AE_Parentesco_3 + String.Empty;
                        objs[28] = item.AE_N4 + String.Empty;
                        objs[29] = item.AE_Nombre_4 + String.Empty;
                        objs[30] = item.AE_Edad_4 + String.Empty;
                        objs[31] = item.AE_Parentesco_4 + String.Empty;
                        objs[32] = item.RegionAgencia + String.Empty;
                        objs[33] = item.ProvinciaAgencia + String.Empty;
                        objs[34] = item.ZonaAgencia + String.Empty;
                        objs[35] = item.Agencia + String.Empty;
                        objs[36] = item.DireccionAgencia + String.Empty;
                        objs[37] = item.TipoCliente + String.Empty;
                        objs[38] = item.FechaDesembolso + String.Empty;
                        objs[39] = item.FechaAgendamiento + String.Empty;
                        objs[40] = item.ResultadoSeguimiento + String.Empty;
                        objs[41] = item.DataGestion0 + String.Empty;
                        objs[42] = item.DataGestion1 + String.Empty;
                        objs[43] = item.DataGestion2 + String.Empty;
                        objs[44] = item.Observaciones_2 + String.Empty;
                        objs[45] = item.Tajeta + String.Empty;
                        objs[46] = item.Cupotarjeta + String.Empty;
                        objs[47] = item.TipoDocumento + String.Empty;
                        objs[48] = item.Documento + String.Empty;
                        objs[49] = item.PrimerNombre + String.Empty;
                        objs[50] = item.SegundoNombre + String.Empty;
                        objs[51] = item.PrimerApellido + String.Empty;
                        objs[52] = item.SegundoApellido + String.Empty;
                        objs[53] = item.Nacionalidad + String.Empty;
                        objs[54] = item.PaisNacimiento + String.Empty;
                        objs[55] = item.ProvinciaNacimiento + String.Empty;
                        objs[56] = item.CiudadNacimeinto + String.Empty;
                        objs[57] = item.FechaNacimiento + String.Empty;
                        objs[58] = item.Genero + String.Empty;
                        objs[59] = item.EstadoCivil + String.Empty;
                        objs[60] = item.Celular + String.Empty;
                        objs[61] = item.EmailPersonal + String.Empty;
                        objs[62] = item.ProvinciaDomicilio + String.Empty;
                        objs[63] = item.CiudadDomicilio + String.Empty;
                        objs[64] = item.CantonDomicilio + String.Empty;
                        objs[65] = item.ParroquiaDomicilio + String.Empty;
                        objs[66] = item.CallePrincipalDomicilio + String.Empty;
                        objs[67] = item.NumeracionDomicilio + String.Empty;
                        objs[68] = item.CalleSecundariaDomicialio + String.Empty;
                        objs[69] = item.SectorBarrioDomicilio + String.Empty;
                        objs[70] = item.ReferenciaDomicilio + String.Empty;
                        objs[71] = item.TelefonoDomicilio + String.Empty;
                        objs[72] = item.SituacionLaboral + String.Empty;
                        objs[73] = item.TipoVivienda + String.Empty;
                        objs[74] = item.ObligadoContabilidad + String.Empty;
                        objs[75] = item.NombreNegocio + String.Empty;
                        objs[76] = item.FechaIniNegocio + String.Empty;
                        objs[77] = item.ActividadEconomica + String.Empty;
                        objs[78] = item.VentasHMensuales + String.Empty;
                        objs[79] = item.CostoVentas + String.Empty;
                        objs[80] = item.GastosOperativos + String.Empty;
                        objs[81] = item.NombreEmpresa + String.Empty;
                        objs[82] = item.Contrato + String.Empty;
                        objs[83] = item.Cargo + String.Empty;
                        objs[84] = item.FechaIniTrabAct + String.Empty;
                        objs[85] = item.Sueldo + String.Empty;
                        objs[86] = item.GastosFamilia + String.Empty;
                        objs[87] = item.ProvinciaTrabajo + String.Empty;
                        objs[88] = item.CiudadTrabajo + String.Empty;
                        objs[89] = item.CantonTrabajo + String.Empty;
                        objs[90] = item.ParroquiaTrabajo + String.Empty;
                        objs[91] = item.CallePrincipalTrabajo + String.Empty;
                        objs[92] = item.NumeracionTrabajo + String.Empty;
                        objs[93] = item.CalleSecundariaTrabajo + String.Empty;
                        objs[94] = item.SectorBarrioTrabajo + String.Empty;
                        objs[95] = item.ReferenciaTrabajo + String.Empty;
                        objs[96] = item.TelefonoTrabajo + String.Empty;
                        objs[97] = item.EmailTrabajo + String.Empty;
                        objs[98] = item.PersonaReferencia + String.Empty;
                        objs[99] = item.PaisReferencia + String.Empty;
                        objs[100] = item.PaisReferencia + String.Empty;
                        objs[101] = item.CiudadReferencia + String.Empty;
                        objs[102] = item.TelefonoReferencia + String.Empty;
                        objs[103] = item.Parentesco + String.Empty;
                        objs[104] = item.LugarEntrega + String.Empty;
                        objs[105] = item.PersonaContacto + String.Empty;
                        objs[106] = item.TelefonoContacto + String.Empty;
                        objs[107] = item.EquipoFutbol + String.Empty;
                        objs[108] = item.HorarioEntrega + String.Empty;

                        /* CUENTA LA CANTIDAD DE LLAMADAS QUE SE HIZO POR CLIENTE */
                        objs[59] = cl_temp.reporte.Count + "";

                        //if (cl_historial.Contains(item.Id_Titular))
                        //    break;

                        int i_helper = 0;
                        int indice = 0;

                        if (cl_temp.reporte.Count > 0)
                        {
                            DateTime fech = DateTime.Parse(cl_temp.reporte[indice].TmStmp);
                            objs[109] = fech.ToString("yyyy-MM-dd");
                            objs[110] = fech.ToString("HH:mm:ss");
                            objs[111] = cl_temp.reporte[indice].ResultLevel1 + "";
                            objs[112] = cl_temp.reporte[indice].ResultLevel2 + "";
                            i_helper++;
                        }
                        else
                        {
                            objs[109] = item.Fecha1 + String.Empty;
                            objs[110] = item.hora1 + String.Empty;
                            objs[111] = item.estatus1 + String.Empty;
                            objs[112] = item.Subestatus1 + String.Empty;
                            
                        }

                        indice = 1;
                        if (cl_temp.reporte.Count > indice)
                        {
                            DateTime fech = DateTime.Parse(cl_temp.reporte[indice].TmStmp);
                            objs[113] = fech.ToString("yyyy-MM-dd");
                            objs[114] = fech.ToString("HH:mm:ss");
                            objs[115] = cl_temp.reporte[indice].ResultLevel1 + "";
                            objs[116] = cl_temp.reporte[indice].ResultLevel2 + "";
                            i_helper++;
                        }
                        else
                        {
                            objs[113] = item.Fecha2 + String.Empty;
                            objs[114] = item.hora2 + String.Empty;
                            objs[115] = item.estatus2 + String.Empty;
                            objs[116] = item.Subestatus2 + String.Empty;
                            
                        }

                        indice = 2;
                        if (cl_temp.reporte.Count > indice)
                        {
                            DateTime fech = DateTime.Parse(cl_temp.reporte[indice].TmStmp);
                            objs[117] = fech.ToString("yyyy-MM-dd");
                            objs[118] = fech.ToString("HH:mm:ss");
                            objs[119] = cl_temp.reporte[indice].ResultLevel1 + "";
                            objs[120] = cl_temp.reporte[indice].ResultLevel2 + "";
                            i_helper++;
                        }
                        else
                        {
                            objs[117] = item.Fecha3 + String.Empty;
                            objs[118] = item.hora3 + String.Empty;
                            objs[119] = item.estatus3 + String.Empty;
                            objs[120] = item.Subestatus3 + String.Empty;
                            
                        }

                        indice = 3;
                        if (cl_temp.reporte.Count > indice)
                        {
                            DateTime fech = DateTime.Parse(cl_temp.reporte[indice].TmStmp);
                            objs[121] = fech.ToString("yyyy-MM-dd");
                            objs[122] = fech.ToString("HH:mm:ss");
                            objs[123] = cl_temp.reporte[indice].ResultLevel1 + "";
                            objs[124] = cl_temp.reporte[indice].ResultLevel2 + "";
                            i_helper++;
                        }
                        else
                        {
                            objs[121] = item.Fecha4 + String.Empty;
                            objs[122] = item.hora4 + String.Empty;
                            objs[123] = item.estatus4 + String.Empty;
                            objs[124] = item.Subestatus4 + String.Empty;
                            
                        }

                        objs[125] = estatus_final;

                        /* CUENTA LA CANTIDAD DE LLAMADAS QUE SE HIZO POR CLIENTE */
                        objs[126] = i_helper + ""; /* ACTUALIZA LOS INTENTOS */


                        cl_historial.Add(cl.Cedula);


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
    }
}
