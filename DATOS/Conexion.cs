﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Xml;

namespace DATOS
{
    public class Conexion
    {
        private String BD_NAME = "BancoPichincha2";

        public Conexion(String BD_NAME = "BancoPichincha2")
        {
            this.BD_NAME = BD_NAME;
        }


        public SqlConnection Conectar()
        {
            SqlConnection cn = null;
            try
            {
                //string conn = ConfigurationManager.ConnectionStrings["Pichincha"].ConnectionString;

                //XmlTextReader reader = new XmlTextReader("ConfigReporter.xml");
                //XmlDocument xDoc = new XmlDocument();
                //xDoc.Load("ConfigReporter.xml");

                //XmlNodeList xConection = xDoc.GetElementsByTagName("ConectionString");
                //String conectString = xConection[0].InnerText;

                String conn = "Server=192.168.100.32;Database=" + this.BD_NAME + ";User Id=usraccmw; password=inc2001;encrypt=false";
                cn = new SqlConnection(conn);
                
            }
            catch (Exception ex)
            {
                
            }
            return cn;
        }
    }
}
