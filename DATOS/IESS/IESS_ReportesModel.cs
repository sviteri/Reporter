using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATOS.IESS
{
    public class IESS_ReportesModel
    {
        Conexion conex = new Conexion();

        public DataTable _get_gestion_cliente()
        {

            DataTable dt = new DataTable();
            SqlConnection myConnection = conex.Conectar_master();
            try
            {
                myConnection.Open();
                String sql = "SELECT TOP 5 * FROM [BDMW-PARTNERS].[IESS].[dbo].[Agendamiento] UNION ALL "+
                "SELECT TOP 5 * FROM [IESS].[dbo].[Agendamiento] UNION ALL "+
                "SELECT TOP 5 * FROM [PARTNERS-GYE].[IESS].[dbo].[Agendamiento]; ";
                SqlCommand cm = new SqlCommand(sql, myConnection);
                SqlDataAdapter da = new SqlDataAdapter(cm);
                SqlDataAdapter da1 = new SqlDataAdapter(cm);
                
                da.Fill(dt);
                da1.Fill(dt);
            }
            catch (Exception)
            {

            }
            finally
            {
                myConnection.Close();

            }

            return dt;

        }
    }
}
