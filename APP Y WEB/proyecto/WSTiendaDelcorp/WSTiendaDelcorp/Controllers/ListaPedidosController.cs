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
    public class ListaPedidosController : ApiController
    {
        // GET: api/ListaPedidos
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/ListaPedidos/5
        public List<Pedido> Get(String idUsuario,String fecInicio,String fecFinal)
        {
            List<Pedido> lstPedido = new List<Pedido>();

            Db obj = new Db();
            DataTable dt = new DataTable();
            dt = obj.ListarPedidos(idUsuario,fecInicio,fecFinal);
              
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

        // POST: api/ListaPedidos
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/ListaPedidos/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/ListaPedidos/5
        public void Delete(int id)
        {
        }
    }
}
