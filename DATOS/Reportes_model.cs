using ENTIDADES;
using ENTIDADES.PichinchaTDCAdicional;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DATOS
{
    public class Reportes_model
    {
        Conexion conex = new Conexion();


        public List<Cliente> _get_gestion_cliente(String id_cliente = null)
        {
            List<Cliente> lista = new List<Cliente>();
           
            SqlConnection myConnection = conex.Conectar();
            try
            {
                myConnection.Open();
                String sql = "SELECT * FROM Cliente;";
                    SqlCommand cm = new SqlCommand(sql, myConnection);
                    SqlDataReader r = cm.ExecuteReader();
                    while (r.Read())
                    {
                        Cliente cl_t = new Cliente();
                        cl_t.Cuenta = r[0].ToString();
                        cl_t.Identificacion = r[1].ToString();
                        cl_t.Nombres = r[2].ToString();
                        cl_t.Apellidos = r[3].ToString();
                        cl_t.Email = r[4].ToString();
                        cl_t.Producto = r[5].ToString();
                        cl_t.Familia = r[6].ToString();
                        cl_t.Cupo = Convert.ToDecimal(r[7].ToString());
                        cl_t.Cupo_disponible = Convert.ToDecimal(r[8].ToString());
                        cl_t.Direccion = r[9].ToString();
                        cl_t.Telefono_domicilio1 = r[10].ToString();
                        cl_t.Telefono_domicilio2 = r[11].ToString();
                        cl_t.Telefono_trabajo = r[12].ToString();
                        cl_t.Telefono1 = r[13].ToString();
                        cl_t.Telefono2 = r[14].ToString();
                        cl_t.Telefono3 = r[15].ToString();
                        cl_t.Celular = r[16].ToString();
                        cl_t.Ciudad = r[17].ToString();
                        cl_t.Genero = r[18].ToString();
                        cl_t.Estado_civil = r[19].ToString();
                        cl_t.Estatus_llamada = r[20].ToString();
                        cl_t.SubEstatus_llamada = r[21].ToString();
                        cl_t.Estado_cuenta_electro = r[22].ToString();
                        cl_t.Observaciones = r[23].ToString();
                        cl_t.Agente = r[24].ToString();
                        cl_t.Celular2 = r[25].ToString();
                        cl_t.Base = r[26].ToString();
                        if (r[27].ToString() != null && r[27].ToString() != "")
                            cl_t.Fecha_creacion = Convert.ToDateTime(r[27].ToString());

                        if (r[28].ToString() != null && r[28].ToString() != "")
                            cl_t.Fecha_rellamar = Convert.ToDateTime(r[28].ToString());
                        cl_t.Hora_rellamar = r[29].ToString();
                        cl_t.Activo = (r[30].ToString() == "1");
                        lista.Add(cl_t);
                    }
                    r.Close();



                    foreach (var cl_tem in lista)
                    {
                    String sql2 = " SELECT TOP 10 g.TmStmp,g.LastAgent,g.ContactAddress,g.TipoDocumento,g.Documento,"+
                    "g.Nacionalidad,g.PrimerNombre,g.SegundoNombre,g.PrimerApellido,g.SegundoApellido,"+
                    "g.NombreTarjeta,g.FechaNacimiento,g.Genero,g.EstadoCivil,g.Parentesco,"+
                    "h.cupo_historial,c.Cuenta,c.Identificacion,g.SubEstatus,c.Nombres,"+
                    "g.ProvinciaTrabajo,g.CiudadTrabajo,g.ParroquiaTrabajo,g.NumeracionTrabajo,g.CallePrincipalTrabajo,"+
                    "g.CalleSecundariaTrabajo,g.SectorBarrioTrabajo,g.EdificioTrabajo,g.ReferenciaTrabajo," +
                    "g.ProvinciaDomicilio,g.CiudadDomicilio,g.ParroquiaDomicilio,g.NumeracionDomicilio,g.CallePrincilaDomicilio,"+
                    "CalleSecundariaDomicialio,g.SectorBarrioDomicilio,g.EdificioDomicilio,g.ReferenciaDomicilio,g.LugarEntrega,g.PersonaContacto,g.RangoVicita," +
                    "g.Celular,g.TelefonoTrabajo,g.TelefonoDomicilio,g.AsistenciaXperta, ISNULL( g.TipoCuota,'Mensual') as Tipo_Cuota,"+
                    "g.AsistenciaExequial,g.AeBnNombre1,g.AeBnParentesco1,g.AeBnNombre2,g.AeBnParentesco2,g.AeBnNombre3,g.AeBnParentesco3,"+
                    "g.AeBnNombre4,AeBnParentesco4,g.LastAgent,g.Estatus,g.Observaciones " +
                    "FROM Gestiones g "+
                    "JOIN Cliente c ON g.IdTitular=c.Identificacion "+
                    "left JOIN Historial h on g.IdTitular=h.cedula_cliente AND "+
                    "g.Documento=h.cedula_beneficiario_historial WHERE g.IdTitular='"+cl_tem.Identificacion+"' " +
                    " ORDER BY g.TmStmp asc ;";
                    SqlCommand cm2 = new SqlCommand(sql2, myConnection);
                    SqlDataReader r2 = cm2.ExecuteReader();

                    List<GestionesCliente> ls_gestiones = new List<GestionesCliente>();
                    GestionesCliente gs=null;

                    while (r2.Read())
                    {
                        gs = new GestionesCliente
                        {
                            Fecha_Gestion = r2["TmStmp"].ToString(),
                            Usuario = r2["LastAgent"].ToString(),
                            Numero_Gestion = r2["ContactAddress"].ToString(),
                            Tipo_Id = r2["TipoDocumento"].ToString(),
                            Id_adicional = r2["Documento"].ToString(),
                            Nacionalidad = r2["Nacionalidad"].ToString(),
                            PrimerNombre = r2["PrimerNombre"].ToString(),
                            SegundoNombre = r2["SegundoNombre"].ToString(),
                            PrimerApellido = r2["PrimerApellido"].ToString(),
                            SegundoApellido = r2["SegundoApellido"].ToString(),
                            Nombre_Tarjeta = r2["NombreTarjeta"].ToString(),
                            FechaNacimiento = r2["FechaNacimiento"].ToString(),
                            Sexo = r2["Genero"].ToString(),
                            EstadoCivil = r2["EstadoCivil"].ToString(),
                            Parentesco = r2["Parentesco"].ToString(),
                            Cupo = r2["cupo_historial"].ToString(),
                            Cuenta_Titular = r2["Cuenta"].ToString(),
                            Id_Titular = r2["Identificacion"].ToString(),
                            Producto = r2["SubEstatus"].ToString(),
                            Nombre_Completo_Titular = r2["Nombres"].ToString(),
                            ProvinciaTrabajo = r2["ProvinciaTrabajo"].ToString(),
                            CiudadTrabajo = r2["CiudadTrabajo"].ToString(),
                            ParroquiaTrabajo = r2["ParroquiaTrabajo"].ToString(),
                            CallePrincipalTrabajo = r2["CallePrincipalTrabajo"].ToString(),
                            NumeracionTrabajo = r2["NumeracionTrabajo"].ToString(),
                            CalleSecundariaTrabajo = r2["CalleSecundariaTrabajo"].ToString(),
                            SectorBarrioTrabajo = r2["SectorBarrioTrabajo"].ToString(),
                            EdificioTrabajo = r2["EdificioTrabajo"].ToString(),
                            ReferenciaTrabajo = r2["ReferenciaTrabajo"].ToString(),
                            ProvinciaDomicilio = r2["ProvinciaDomicilio"].ToString(),
                            CiudadDomicilio = r2["CiudadDomicilio"].ToString(),
                            ParroquiaDomicilio = r2["ParroquiaDomicilio"].ToString(),
                            CallePrincilaDomicilio = r2["CallePrincilaDomicilio"].ToString(),
                            NumeracionDomicilio = r2["NumeracionDomicilio"].ToString(),
                            CalleSecundariaDomicialio = r2["CalleSecundariaDomicialio"].ToString(),
                            SectorBarrioDomicilio = r2["SectorBarrioDomicilio"].ToString(),
                            EdificioDomicilio = r2["EdificioDomicilio"].ToString(),
                            ReferenciaDomicilio = r2["ReferenciaDomicilio"].ToString(),
                            LugarEntrega = r2["LugarEntrega"].ToString(),
                            PersonaContacto = r2["PersonaContacto"].ToString(),
                            RangoVicita = r2["RangoVicita"].ToString(),
                            Celular = r2["Celular"].ToString(),
                            TelefonoTrabajo = r2["TelefonoTrabajo"].ToString(),
                            TelefonoDomicilio = r2["TelefonoDomicilio"].ToString(),
                            AsistenciaXperta = r2["AsistenciaXperta"].ToString(),
                            TipoCuota = r2["Tipo_Cuota"].ToString(),
                            AsistenciaExequial = r2["AsistenciaExequial"].ToString(),
                            Beneficiario_1_Nombre = r2["AeBnNombre1"].ToString(),
                            Beneficiario_1_Apellido = r2["AeBnNombre1"].ToString(),
                            Beneficiario_1_Parentesco = r2["AeBnParentesco1"].ToString(),
                            Beneficiario_2_Nombre = r2["AeBnNombre2"].ToString(),
                            Beneficiario__2_Apellido = r2["AeBnNombre2"].ToString(),
                            Beneficiario_2_Parentesco = r2["AeBnParentesco2"].ToString(),
                            Beneficiario_3_Nombre = r2["AeBnNombre3"].ToString(),
                            Beneficiario_3_Apellido = r2["AeBnNombre3"].ToString(),
                            Beneficiario_3_Parentesco = r2["AeBnParentesco3"].ToString(),
                            Beneficiario_4_Nombre = r2["AeBnNombre4"].ToString(),
                            Beneficiario_4_Apellido = r2["AeBnNombre4"].ToString(),
                            Beneficiario_4_Parentesco = r2["AeBnParentesco4"].ToString(),
                            operador = r2["LastAgent"].ToString(),
                            status_final = null,
                            intento = 0 + "",
                            Estatus = r2["Estatus"].ToString(),
                            Observaciones = r2["Observaciones"].ToString(),
                            LastEstatus = cl_tem.Estatus_llamada
                        };

                        ls_gestiones.Add(gs);
                        cl_tem.gestiones = ls_gestiones;
                    }
                    r2.Close();
                    
                    }
            }
            catch (Exception)
            {

            }
            finally
            {
                myConnection.Close();

            }

            return lista;
            
        }

       
    }
}
