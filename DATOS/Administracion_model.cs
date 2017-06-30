using ENTIDADES;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATOS
{
    public class Administracion_model
    {
        Conexion conex = new Conexion();

        public Usuario get_usuario_by_credenciales(String nick,String clave)
        {
            SqlConnection myConnection = conex.Conectar();
            Usuario u = new Usuario();

            try
            {
                myConnection.Open();
                String sql = "SELECT * FROM Usuario WHERE seudonimo_usuario='"+nick+"' AND clave_usuario='"+clave+"' AND estado_usuario=1;";
                SqlCommand cm = new SqlCommand(sql, myConnection);
                SqlDataReader r = cm.ExecuteReader();
                while (r.Read())
                {
                    u.id = r.GetInt32(0);
                    u.id_rol = r.GetInt32(1);
                    u.nombre = r.GetString(2);
                    u.seudonimo = r.GetString(3);
                    u.clave = r.GetString(4);
                    u.estado = r.GetBoolean(5);
                }
            }
            catch (Exception)
            {

            }
            finally
            {
                myConnection.Close();

            }

            return u;
        }

    }
}
