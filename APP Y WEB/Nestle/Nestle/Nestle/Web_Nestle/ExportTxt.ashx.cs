using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Web_Nestle
{
    /// <summary>
    /// EXPORTATAR TXT PEDIDO Y DETALLE EN UNA SOLA EJECUCION :)
    /// </summary>
    public class ExportTxt : IHttpHandler
    {
        private string fullpath;
        public void ProcessRequest(HttpContext context)
        {
            //NELSON :)
            String dir = System.Web.HttpContext.Current.Server.MapPath("~\\ExportPedido\\" + context.Request.QueryString["filepath"].ToString() + "");
            fullpath = dir;// @"C:\Users\Desarrollador\Desktop\Nestle\Nestle\Web_Nestle\PruebaNm\" + context.Request.QueryString["filepath"].ToString()+"";// System.Web.HttpContext.Current.Server.MapPath(HttpUtility.UrlDecode(GuardarCabecera+context.Request.QueryString["filepath"]));
          
            FileInfo file = new FileInfo(fullpath);
            if (file.Exists)
            {
                context.Response.AddHeader("Content-Disposition", "attachment; filename=\"" + file.Name + "\"");
                context.Response.AddHeader("Content-Length", file.Length.ToString());
                context.Response.WriteFile(file.FullName);
                context.Response.End();
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}