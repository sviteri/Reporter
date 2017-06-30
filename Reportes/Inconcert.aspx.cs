using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Reportes
{
    public partial class Inconcert : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            tester();
        }

        public void tester()
        {
            inConcertSDKnet.CSession session = new inConcertSDKnet.CSession("sviteri@serviportex", "serviportex");
            inConcertSDKnet.APIResult lResult = session.Login("sviteri", "TCADICIONALPICHINCHA", "192.168.100.45", 8082);

           

            lbl_mensaje.Text = "ID llamada:" + (lResult.OK);


        }
    }
}