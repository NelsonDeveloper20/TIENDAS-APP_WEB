using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WSTiendaDelcorp.Models;

namespace WSTiendaDelcorp.Controllers
{
    public class PedidosV2Controller : ApiController
    {
        // GET: api/PedidosV2
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/PedidosV2/5
        public List<Pedido> Get(String idUsuario)
        {
            List<Pedido> lstPedido = new List<Pedido>();

            Db obj = new Db();
            DataTable dt = new DataTable();
            dt = obj.ListarPedidos(idUsuario);


            foreach (DataRow row in dt.Rows)
            {
                Pedido objPedido = new Pedido();
                objPedido.IdPedido = row["IdPedido"].ToString();
                objPedido.IdUsuario = row["IdUsuario"].ToString();
                objPedido.NomCliente = row["NomCliente"].ToString();
                objPedido.IdCondicionVenta = row["IdCondicionVenta"].ToString();
                objPedido.IdUsuarioVenta = row["IdUsuarioVenta"].ToString();
                objPedido.TotalPagar = row["TotalPagar"].ToString();
                objPedido.Cantidad = row["Cantidad"].ToString();
                objPedido.Latitud = row["Latitud"].ToString();
                objPedido.Longitud = row["Longitud"].ToString();
                objPedido.Fecha = row["Fecha"].ToString();
                objPedido.FecCrea = row["FecCrea"].ToString();

                lstPedido.Add(objPedido);

            }

            return lstPedido;
        }

        // POST: api/PedidosV2
        public IHttpActionResult Post(List<PedidoDetalle> lista)
        { 
            List<PedidoDetalleRespuesta> lstPedidoDetalleRespuesta = new List<PedidoDetalleRespuesta>();
            ParametrosSalida respuesta = new ParametrosSalida();
            DataTable dt = new DataTable();
            DataTable dt2 = new DataTable();
            try
            {
                DataTable dtPedidoDetalle = new DataTable();
                dtPedidoDetalle.Columns.Add("IdProductoTxt", typeof(string));
                dtPedidoDetalle.Columns.Add("NombrePro", typeof(string));
                dtPedidoDetalle.Columns.Add("Precio", typeof(string));
                dtPedidoDetalle.Columns.Add("Cantidad", typeof(Int32));
                dtPedidoDetalle.Columns.Add("SubTotal", typeof(string));
                dtPedidoDetalle.Columns.Add("IdPromocion", typeof(string));
                dtPedidoDetalle.Columns.Add("IdCondicion", typeof(string));
                dtPedidoDetalle.Columns.Add("IdBonificacion", typeof(string));
                dtPedidoDetalle.Columns.Add("Imagen", typeof(string));

                Db obj = new Db();
                List<PedidoDetalle> lst = new List<PedidoDetalle>();
                for (int i = 0; i < lista.Count; i++)
                {

                    DataRow drog = dtPedidoDetalle.NewRow();
                    drog["IdProductoTxt"] = lista[i].IdProductoTxt;
                    drog["NombrePro"] = lista[i].NombrePro;
                    drog["Precio"] = lista[i].Precio;
                    drog["Cantidad"] = lista[i].Cantidad;
                    drog["SubTotal"] = lista[i].SubTotal;

                    drog["IdPromocion"] = lista[i].IdPromocion;
                    drog["IdCondicion"] = lista[i].IdCondicion;
                    drog["IdBonificacion"] = lista[i].IdBonificacion;
                    drog["Imagen"] = lista[i].Imagen;
                    dtPedidoDetalle.Rows.Add(drog);
                }

                dt = obj.InsertarPedidoV2(lista[0].IdUsuario,
                                              lista[0].CodigoTxt,
                                               Int32.Parse(lista[0].IdCondicionVenta),
                                                lista[0].IdUsuarioVenta,
                                                lista[0].TotalPagar,
                                                Int32.Parse(lista[0].Items),
                                                lista[0].Latitud,
                                                lista[0].Longitud,
                                                Int32.Parse(lista[0].FlagTipoRegistro),
                                                lista[0].Fecha,
                                                 dtPedidoDetalle);

                foreach (DataRow row in dt.Rows)
                {
                    PedidoDetalleRespuesta objj = new PedidoDetalleRespuesta();
                    objj.IdProductoTxt = row["IdProductoTxt"].ToString();
                    objj.NombrePro = row["NombrePro"].ToString();
                    objj.Precio = row["Precio"].ToString();
                    objj.Cantidad = row["Cantidad"].ToString();
                    objj.SubTotal = row["SubTotal"].ToString();
                    objj.IdPromocion = row["IdPromocion"].ToString();
                    objj.IdCondicion = row["IdCondicion"].ToString();
                    objj.IdBonificacion = row["IdBonificacion"].ToString();
                    objj.Imagen = row["Imagen"].ToString();

                    lstPedidoDetalleRespuesta.Add(objj);

                }
  
                if(lstPedidoDetalleRespuesta.Count()==1 && lstPedidoDetalleRespuesta.ElementAt(0).IdProductoTxt.Equals("2"))
                {
                    dt2 = obj.ListaTokenVendedores(lista[0].IdUsuario);
                    foreach (DataRow row in dt2.Rows)
                    {
                         
                        obj.NotificacionMasivaNueva(row["token"].ToString(), 2,"ALERTA COMPRA BAJA"
                            ,"El Cliente "+ lstPedidoDetalleRespuesta.ElementAt(0).Imagen+
                            "  acaba de realizar uan compra por el monto : S/. "+ lstPedidoDetalleRespuesta.ElementAt(0).SubTotal
                            +" ,el cual es menor a su monto sugerido : S/. "+
                            lstPedidoDetalleRespuesta.ElementAt(0).Cantidad
                             , row["cantComp"].ToString());

                    }
                }

            }
            catch (Exception e)
            {
                lstPedidoDetalleRespuesta.Clear();
                PedidoDetalleRespuesta objj = new PedidoDetalleRespuesta();
                objj.IdProductoTxt ="1";
                objj.NombrePro = "ERROR EN API COMUNIQUESE CON SISTEMAS";
                objj.Precio = "0";
                objj.Cantidad = "0";
                objj.SubTotal = "0";
                objj.IdPromocion = "0";
                objj.IdCondicion = "0";
                objj.IdBonificacion = "0";
                objj.Imagen = "0";

                lstPedidoDetalleRespuesta.Add(objj);
            }
            finally
            {

            }

            return  CreatedAtRoute("DefaultApi", new { Id = 1 }, lstPedidoDetalleRespuesta); 
        }

        // PUT: api/PedidosV2/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/PedidosV2/5
        public void Delete(int id)
        {
        }
    }
}
