using DB;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Configuration;

namespace Web_Nestle
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        string conStr = ConfigurationManager.ConnectionStrings["sqlConString"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
          
        
         }

        public void Obtener()
        {
            DataTable Dt = new DataTable();
            var notificationRegisterTime = Session["LastUpdated"] != null ? Convert.ToDateTime(Session["LastUpdated"]) : DateTime.Now;
            using (SqlDataAdapter adp = new SqlDataAdapter("cc_obtenerPush", conStr))
            {
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.Parameters.AddWithValue("@Fecha", notificationRegisterTime);
                adp.Fill(Dt);
            }
            GridView1.DataSource = Dt;
            GridView1.DataBind();
            DtList.DataSource = Dt;
            DtList.DataBind();


        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            Obtener();
        }
        #region METODO SERVICIE M  NELS :)
        [System.Web.Services.WebMethod]   // Marcamos el método como uno web
        public static List<Notifiacion> ObtenerNotificacion(String Fecha)
        {

            List<Notifiacion> datosuser = new List<Notifiacion>();
            String Msj = "";
            string conStr = ConfigurationManager.ConnectionStrings["sqlConString"].ConnectionString;
            DataTable Dt = new DataTable();
            //var notificationRegisterTime = Session["LastUpdated"] != null ? Convert.ToDateTime(Session["LastUpdated"]) : DateTime.Now;
            using (SqlDataAdapter adp = new SqlDataAdapter("cc_obtenerPush", conStr))
            {
              
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                //adp.SelectCommand.Parameters.AddWithValue("@Fecha", notificationRegisterTime);
                adp.Fill(Dt);
            }
            foreach (DataRow row in Dt.Rows)
            {
                Notifiacion Serv = new Notifiacion();
                Serv.IdUsuario =Convert.ToInt32(row["idPush"].ToString());
                Serv.Descripcion = row["Descripcion"].ToString();
                Serv.Fecha = row["FecCrea"].ToString();
                datosuser.Add(Serv);
            }

            return datosuser;
        }

        public class Notifiacion
        {
            public int IdUsuario { get; set; }
            public String Descripcion { get; set; }
            public String Fecha { get; set; }
        }
        #endregion
    }
}