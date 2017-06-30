using ENTIDADES.BP_MultiOferta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTIDADES.MultiOferta
{
    public class Cliente
    {
        public Int32 IdUnico { get; set; }
        public String ImportName { get; set; }
        public String VirtualCC { get; set; }
        public String Usuario { get; set; }
        public String Campania { get; set; }
        public String ContactId { get; set; }
        public String Cedula { get; set; }
        public String NUP { get; set; }
        public String Nombre { get; set; }
        public String ActualizacionBI { get; set; }
        public String ClienteBanco { get; set; }
        public String CalificacionBuro { get; set; }
        public String PerfilRiesgoEndeudamiento { get; set; }
        public String Subsegmento { get; set; }
        public String Edad { get; set; }
        public String NOMBRE_CREDITO_1 { get; set; }
        public String CREDITO_1 { get; set; }
        public String CUOTA_CREDITO_1 { get; set; }
        public String GARANTE_CREDITO_1 { get; set; }
        public String REQUIERE_PRECANCELAR_1 { get; set; }
        public String MONTO_RETANQUEO_1 { get; set; }
        public String PLAZO_RETANQUEO_1 { get; set; }
        public String CUOTA_RETANQUEO_1 { get; set; }
        public String TARJETA_1 { get; set; }
        public String PRODUCTO_TDC_1 { get; set; }
        public String INFORMACION_ADICIONAL_1 { get; set; }
        public String NOMBRE_CREDITO_2 { get; set; }
        public String CREDITO_2 { get; set; }
        public String CUOTA_CREDITO_2 { get; set; }
        public String GARANTE_CREDITO_2 { get; set; }
        public String REQUIERE_PRECANCELAR_2 { get; set; }
        public String MONTO_RETANQUEO_2 { get; set; }
        public String PLAZO_RETANQUEO_2 { get; set; }
        public String CUOTA_RETANQUEO_2 { get; set; }
        public String TARJETA_2 { get; set; }
        public String PRODUCTO_TDC_2 { get; set; }
        public String INFORMACION_ADICIONAL_2 { get; set; }
        public String NOMBRE_CREDITO_3 { get; set; }
        public String CREDITO_3 { get; set; }
        public String CUOTA_CREDITO_3 { get; set; }
        public String GARANTE_CREDITO_3 { get; set; }
        public String REQUIERE_PRECANCELAR_3 { get; set; }
        public String MONTO_RETANQUEO_3 { get; set; }
        public String PLAZO_RETANQUEO_3 { get; set; }
        public String CUOTA_RETANQUEO_3 { get; set; }
        public String TARJETA_3 { get; set; }
        public String PRODUCTO_TDC_3 { get; set; }
        public String INFORMACION_ADICIONAL_3 { get; set; }
        public String NOMBRE_CREDITO_4 { get; set; }
        public String CREDITO_4 { get; set; }
        public String CUOTA_CREDITO_4 { get; set; }
        public String GARANTE_CREDITO_4 { get; set; }
        public String REQUIERE_PRECANCELAR_4 { get; set; }
        public String MONTO_RETANQUEO_4 { get; set; }
        public String PLAZO_RETANQUEO_4 { get; set; }
        public String CUOTA_RETANQUEO_4 { get; set; }
        public String TARJETA_4 { get; set; }
        public String PRODUCTO_TDC_4 { get; set; }
        public String INFORMACION_ADICIONAL_4 { get; set; }
        public String NOMBRE_CREDITO_5 { get; set; }
        public String CREDITO_5 { get; set; }
        public String CUOTA_CREDITO_5 { get; set; }
        public String GARANTE_CREDITO_5 { get; set; }
        public String REQUIERE_PRECANCELAR_5 { get; set; }
        public String MONTO_RETANQUEO_5 { get; set; }
        public String PLAZO_RETANQUEO_5 { get; set; }
        public String CUOTA_RETANQUEO_5 { get; set; }
        public String TARJETA_5 { get; set; }
        public String PRODUCTO_TDC_5 { get; set; }
        public String INFORMACION_ADICIONAL_5 { get; set; }
        public String NOMBRE_CREDITO_6 { get; set; }
        public String CREDITO_6 { get; set; }
        public String CUOTA_CREDITO_6 { get; set; }
        public String GARANTE_CREDITO_6 { get; set; }
        public String REQUIERE_PRECANCELAR_6 { get; set; }
        public String MONTO_RETANQUEO_6 { get; set; }
        public String PLAZO_RETANQUEO_6 { get; set; }
        public String CUOTA_RETANQUEO_6 { get; set; }
        public String TARJETA_6 { get; set; }
        public String PRODUCTO_TDC_6 { get; set; }
        public String INFORMACION_ADICIONAL_6 { get; set; }
        public String MAX_CREDITO { get; set; }
        public String MAX_TDC { get; set; }
        public String codigo_asesor { get; set; }
        public String fecha_nacimiento { get; set; }
        public String sexo { get; set; }
        public String numero_cuenta { get; set; }
        public String tipo_cuenta { get; set; }
        public String estado_civil { get; set; }
        public String provincia_dom { get; set; }
        public String codigo_ciudad_1 { get; set; }
        public String tele01_dom { get; set; }
        public String codigo_ciudad_2 { get; set; }
        public String tele02_dom { get; set; }
        public String codigo_ciudad_3 { get; set; }
        public String tele01_trab { get; set; }
        public String codigo_ciudad_4 { get; set; }
        public String tele02_trab { get; set; }
        public String celular { get; set; }
        public String email { get; set; }
        public String ciudad_dom { get; set; }
        public String direc_dom { get; set; }
        public String provincia_trab { get; set; }
        public String ciudad_trab { get; set; }
        public String direc_trab { get; set; }
        public String agencia { get; set; }
        public String zona { get; set; }
        public String region { get; set; }
        public String status_cuenta { get; set; }
        public String ruc { get; set; }
        public String empresa { get; set; }
        public String ROLERO { get; set; }
        public String NOMBRE_EMPRESA_ROLERA { get; set; }
        public String Asistencia_Xperta { get; set; }
        public String Asistencia_Exequial { get; set; }
        public String Tiene_Xperta { get; set; }
        public String Xperta_Activa { get; set; }
        public String Gestionado_Xperta { get; set; }
        public String Gestionado_Exequial { get; set; }
        public String GestionAXperta { get; set; }
        public String GestionExequial { get; set; }
        public String InteractionId { get; set; }
        public String ContactAddress { get; set; }
        public String FechaHora { get; set; }
        public String FechaHoraAgenda { get; set; }
        public String Intentos { get; set; }
        public String EstadoGestion { get; set; }
        public String TAdicional { get; set; }
        public String Agente { get; set; } 

        public List<GestionMO_report> reporte { get; set; }

     

    }
}
