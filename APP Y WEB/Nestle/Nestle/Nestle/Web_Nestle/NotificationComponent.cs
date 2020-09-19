using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Web_Nestle
{
    public class NotificationComponent
    {//http://www.dotnetawesome.com/2016/05/push-notification-system-with-signalr.html
        //Aquí agregaremos una función para la notificación de registro (agregaremos dependencia de sql)
        string conStr = ConfigurationManager.ConnectionStrings["sqlConString"].ConnectionString;

        public void RegisterNotification(DateTime currentTime)
        {
            //string sqlCommand = @"SELECT IdServicio, Direccion, Telefono, FecCrea, Estado FROM dbo.Servicio WHERE FecCrea  > @AddedOn";
            string sqlCommand = @"SELECT idPush, idUsuario, Descripcion, FecCrea, Estado FROM dbo.PushExportTxt WHERE FecCrea > @AddedOn";
            //Puedes notar aquí que he agregado un nombre de tabla como este [dbo]. [Contactos] con [dbo], su mendatorio cuando usas la dependencia de SQL
            using (SqlConnection con = new SqlConnection(conStr))
            {
                SqlCommand cmd = new SqlCommand(sqlCommand, con);
                cmd.Parameters.AddWithValue("@AddedOn", currentTime);
                if (con.State != System.Data.ConnectionState.Open)
                {
                    con.Open();
                }
                cmd.Notification = null;
                SqlDependency sqlDep = new SqlDependency(cmd);
                sqlDep.OnChange += sqlDep_OnChange;
                // debemos tener que ejecutar el comando aquí
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    //   nada hay que agregar aquí ahora
                }
            }

        }

        void sqlDep_OnChange(object sender, SqlNotificationEventArgs e)
        {
            if (e.Type == SqlNotificationType.Change)
            {
                SqlDependency sqlDep = sender as SqlDependency;
                sqlDep.OnChange -= sqlDep_OnChange;

                //           Desde aquí enviaremos un mensaje de notificación al cliente.
                var notificationHub = GlobalHost.ConnectionManager.GetHubContext<NotificationHub>();
                notificationHub.Clients.All.notify("added");
                //re-register notification
                RegisterNotification(DateTime.Now);

            }
        }

    }
}