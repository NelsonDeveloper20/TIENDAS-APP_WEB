using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Newtonsoft.Json.Linq;
using System.Net;
using System.IO;

namespace Web_Nestle
{
    public partial class WebForm6 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {



        }
        protected void UploadDocument(object sender, EventArgs e)
        {
            TextBox3.Text = distrito(TextBox1.Text, TextBox2.Text);
        }
        public static string distrito(string lat, string lng)
        {
            string result = "";
            JObject obje = null;
            string latlng = lat + "," + lng;
            string urlss = "https://maps.googleapis.com/maps/api/geocode/json?latlng=" + latlng + "&key=AIzaSyDiX_f2Q96kPTLH3-66rWLqHOKEBXazkCA";
            HttpWebResponse response = null;
            string strRes;
            try
            {
                var encoding = new ASCIIEncoding();
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(urlss);
                request.Method = "GET";
                request.KeepAlive = false;
                request.ContentType = "application/json";
                response = (HttpWebResponse)request.GetResponse();
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    Encoding enc = System.Text.Encoding.GetEncoding(1252);
                    StreamReader loResponseStream = new StreamReader(response.GetResponseStream(), enc);
                    strRes = loResponseStream.ReadToEnd();
                    obje = Newtonsoft.Json.JsonConvert.DeserializeObject<JObject>(strRes);
                    JToken vla = obje.Value<JToken>("results");
                    var arrayleg = vla.Value<JArray>();
                    for (int j = 0; j < arrayleg.Count; j++)
                    {
                        var address = arrayleg[j]["address_components"];
                        var arrayaddres = address.Value<JArray>();
                        for (int i = 0; i < arrayaddres.Count; i++)
                        {
                            JToken _type = arrayaddres[i]["types"];
                            var _typearray = _type.Value<JArray>();
                            if (_typearray.Count > 1)
                            {
                                if (_typearray[0].ToString() == "administrative_area_level_3")
                                {
                                    var dis = arrayaddres[i]["long_name"];
                                    result = dis.ToString();
                                }
                            }
                        }
                    }
                    response.Close();
                }
            }
            catch (Exception)
            {
                result = "";
                throw;
            }
            finally
            {
                response.Close();
            }
            return result;
        }
    }
}