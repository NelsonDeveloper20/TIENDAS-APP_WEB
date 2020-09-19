using System;
using System.Collections.Generic;
using System.Data;
using System.Web.Http;
using System.Web.UI.WebControls;
using WSTiendaDelcorp.Models;

namespace WSTiendaDelcorp.Controllers
{
    public class PedidosController : ApiController
    {
        // GET: api/Pedidos
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Pedidos/5
        public List<Pedido> Get(String idUsuario )
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

        // POST: api/Pedidos
        public IHttpActionResult Post(List<PedidoDetalle> lista)
        {
            ParametrosSalida respuesta = new ParametrosSalida();

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
                 for(int i =0; i < lista.Count; i++)
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
                   
                   respuesta = obj.InsertarPedido( lista[0].IdUsuario ,
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
                 
            }
            catch (Exception e)
            {
                respuesta.FlagIndicador = "1";
                respuesta.MsgValidacion = e.Message;
            }
            finally
            {

            }

            return CreatedAtRoute("DefaultApi", new { Id = 1 }, respuesta);

        }

        // PUT: api/Pedidos/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Pedidos/5
        public void Delete(int id)
        {
        }


        
    }
}
