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
    public class ListaDetallePedidoCompController : ApiController
    {
        // GET: api/ListaDetallePedidoComp
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/ListaDetallePedidoComp/5
        public List<PedidoComplementarioDetalle> Get(String IdPedido)
        {
            List<PedidoComplementarioDetalle> lstPedidoComplementarioDetalle = new List<PedidoComplementarioDetalle>();

            Db obj = new Db();
            DataTable dt = new DataTable();
            dt = obj.ListarPedidoComplementarioDetalle(IdPedido);

            foreach (DataRow row in dt.Rows)
            {
                PedidoComplementarioDetalle objPed  = new PedidoComplementarioDetalle();
                objPed.IdPedido = row["IdPedido"].ToString();
                objPed.IdProducto = row["IdProducto"].ToString();
                objPed.IdCategoria = row["IdCategoria"].ToString();
                objPed.IdCategoriaPadre = row["IdCategoriaPadre"].ToString();
                objPed.IdFabricante = row["IdFabricante"].ToString();
                objPed.NombrePro = row["NombrePro"].ToString();
                objPed.Descripcion = row["Descripcion"].ToString();
                objPed.Precio = row["Precio"].ToString();
                objPed.Peso = row["Peso"].ToString();
                objPed.Imagen = row["Imagen"].ToString();
                objPed.IdAlmacen = row["IdAlmacen"].ToString();
                objPed.Stock = row["Stock"].ToString();
                objPed.CantComprada = row["CantComprada"].ToString();
                objPed.CantSugerido = row["CantSugerido"].ToString(); 

                lstPedidoComplementarioDetalle.Add(objPed);

            }

            return lstPedidoComplementarioDetalle;
        }

        // POST: api/ListaDetallePedidoComp
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/ListaDetallePedidoComp/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/ListaDetallePedidoComp/5
        public void Delete(int id)
        {
        }
    }
}
