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
    public class ListaPedidoDetalleController : ApiController
    {
        // GET: api/ListaPedidoDetalle
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/ListaPedidoDetalle/5
        public List<PedidoDetalleLista> Get(String IdPedido)
        {
            List<PedidoDetalleLista> lstPedidoDetalleLista = new List<PedidoDetalleLista>();

            Db obj = new Db();
            DataTable dt = new DataTable();
            dt = obj.ListaPedidoDetalleLista(IdPedido);
            
            foreach (DataRow row in dt.Rows)
            {
                PedidoDetalleLista objPedidoDetalleLista = new PedidoDetalleLista();
                objPedidoDetalleLista.IdPedidoDetalle = row["IdPedidoDetalle"].ToString();
                objPedidoDetalleLista.IdProducto = row["IdProducto"].ToString();
                objPedidoDetalleLista.NombrePro = row["NombrePro"].ToString();
                objPedidoDetalleLista.Precio = row["Precio"].ToString();
                objPedidoDetalleLista.Cantidad = row["Cantidad"].ToString();
                objPedidoDetalleLista.SubTotal = row["SubTotal"].ToString();
                objPedidoDetalleLista.Imagen = row["Imagen"].ToString();
                lstPedidoDetalleLista.Add(objPedidoDetalleLista);

            }
            return lstPedidoDetalleLista;
        }

        // POST: api/ListaPedidoDetalle
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/ListaPedidoDetalle/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/ListaPedidoDetalle/5
        public void Delete(int id)
        {
        }
    }
}
