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

        public DataTable _ejecutar_consulta(String fecha)
        {
            DataTable dt = new DataTable();
            SqlConnection myConnection = conex.Conectar_master();
            try
            {
                myConnection.Open();

                String sql = "SELECT "+
                    "ROW_NUMBER() OVER(ORDER BY iad.StartDate DESC) as id_llamada, "+
                    "cid.CallerId as telefono, "+
                    "CASE "+
                    "WHEN ll.vMenuP = 1 THEN 'Ingreso Cédula; Opciones; mensage_grabacion_IESS02; agendamiento' "+
                    "WHEN ll.vMenuP = 2 THEN 'Ingreso Cédula; Opciones; mensage_grabacion_IESS02; cancelacion'  "+
                    "WHEN ll.vMenuP = 3 THEN 'Ingreso Cédula; Opciones; mensage_grabacion_IESS02; informacion_general'  "+
                    "WHEN ll.vMenuP IS NULL AND ll.AGTEWF_IdInstancia IS NULL THEN '' "+
                    "ELSE 'Ingreso Cédula; Opciones; mensage_grabacion_IESS02' "+
                    "END as ivr, "+
                    "ll.vMenuP as opcion, "+
                    "CASE  "+
                    "WHEN ll.vMenuP = 1 THEN 'AGENDAMIENTO' "+
                    "WHEN ll.vMenuP = 2 THEN 'CANCELACION' "+
                    "WHEN ll.vMenuP = 3 THEN 'INFORMACION GENERAL' "+
                    "ELSE '' "+
                    "END as acd, "+
                    "iad.Actor as usuario, "+
                    "CASE "+
                    "WHEN (select top 1 resultado from [IESS].[dbo].[gestion] where [IESS].[dbo].[gestion].InteractionId=iad.id) IS NULL AND ll.AGTEWF_IdInstancia IS NOT NULL THEN 'SIN [IESS].[dbo].[gestion]'  "+
                    "WHEN (select top 1 resultado from [IESS].[dbo].[gestion] where [IESS].[dbo].[gestion].InteractionId=iad.id) IS NULL AND ll.AGTEWF_IdInstancia IS NULL THEN '' "+
                    "ELSE (select top 1 resultado from [IESS].[dbo].[gestion] where [IESS].[dbo].[gestion].InteractionId=iad.id)  "+
                    "END as Tipificacion, "+
                    "CASE  "+
                    "WHEN iad.IsSentToAgentSearch = 0 THEN 'IVR'  "+
                    "ELSE 'CONTESTADA'  "+
                    "END as Tipo1, "+
                    "'RECIBIDA' as Tipo2, "+
                    "convert(varchar(10), [HistoricalData].dbo.GetRealDate('ECT', iad.StartDate), 103)	'StartDate', "+
                    "convert(varchar(8), [HistoricalData].dbo.GetRealDate('ECT', iad.StartDate), 114)	'StartTime', "+
                    "Convert(varchar(10), [HistoricalData].dbo.GetRealDate('ECT', iad.EndDate), 103)	'EndDate', "+
                    "Convert(varchar(8), [HistoricalData].dbo.GetRealDate('ECT', iad.EndDate), 114)	'EndTime', "+
                    "HistoricalData.dbo.ConvertHourMin( convert(int,iad.DurationTime)) 'Tiempo Total', "+
                    "HistoricalData.dbo.ConvertHourMin( convert(int,iad.WaitTime)) 'Tiempo Espera', "+
                    "HistoricalData.dbo.ConvertHourMin( convert(int,iad.IVRTime)) 'Tiempo IVR', "+
                    "HistoricalData.dbo.ConvertHourMin( convert(int,iad.AttentionTime)) 'Tiempo Atencion',  "+
                    "HistoricalData.dbo.ConvertHourMin( convert(int,iad.WrapupTime)) 'Tiempo Wrapup', "+
                    "HistoricalData.dbo.ConvertHourMin( convert(int,iad.DesertionTime)) 'Tiempo Abandono', "+
                    "HistoricalData.dbo.ConvertHourMin( convert(int,iad.HoldTime)) 'Tiempo Hold', "+
                    "HistoricalData.dbo.ConvertHourMin( convert(int,iad.RingingTime)) 'RingingTime', "+
                    "HistoricalData.dbo.ConvertHourMin( convert(int,iad.WaitTime-iad.RingingTime)) 'Tiempo ACD', "+
                    "CASE WHEN convert(int,iad.WaitTime) >5 AND convert(int,iad.WaitTime) <21  AND iad.Disposition!='' THEN 1 ELSE 0 END 'SVL AB', "+
                    "IAD.IsTransferred 'IsTransferred', "+
                    "DATEPART(DD,[HistoricalData].dbo.GetRealDate('ECT', iad.EndDate)) 'DIA', "+
                    "DATEPART(HOUR,[HistoricalData].dbo.GetRealDate('ECT', iad.EndDate)) 'HORA' "+
                    ",iad.Disposition 'Disposition' "+
                    "fROM [HistoricalData].[dbo].[InteractionActorDetail] as iad (NOLOCK) "+
                    "LEFT JOIN [IESS].[dbo].[llamadas] as ll ON ll.AGTEWF_IdInstancia = iad.id "+
                    " LEFT JOIN [HistoricalData].[dbo].[CallInteractionDetail] as cid ON cid.id = iad.id "+
                    "WHERE "+
                    "iad.EndDate >= [HistoricalData].[dbo].GetInvRealDate('ECT','"+fecha+" 00:00:00') "+
                    "and iad.EndDate <  [HistoricalData].[dbo].GetInvRealDate('ECT','" + fecha + " 23:59:59') " +
                    "AND iad.Campaign = 'IESS_AGENDAMIENTO' "+
                    "ORDER BY iad.StartDate asc;";
                SqlCommand cm = new SqlCommand(sql, myConnection);
                SqlDataAdapter da = new SqlDataAdapter(cm);
                da.SelectCommand = cm;
                cm.CommandTimeout = 0;

                da.Fill(dt);


            }
            catch (Exception)
            {
                
                
            }

            return dt;
        }

    }
}
