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
    public class ListaPedidoComplementarioController : ApiController
    {
        // GET: api/ListaPedidoComplementario
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/ListaPedidoComplementario/5
        public List<PedidoComplementario> Get(String  IdUsuario)
        {
            List<PedidoComplementario> lstPedidoComplementario = new List<PedidoComplementario>();

            Db obj = new Db();
            DataTable dt = new DataTable();
            dt = obj.ListaPedidoComplementario(IdUsuario );


            foreach (DataRow row in dt.Rows)
            {
                PedidoComplementario objPedidoComplementario = new PedidoComplementario();
                objPedidoComplementario.IdPedido = row["IdPedido"].ToString();
                objPedidoComplementario.IdUsuario = row["IdUsuario"].ToString();
                objPedidoComplementario.nomUsuario = row["nomUsuario"].ToString();
                objPedidoComplementario.montoComprado = row["montoComprado"].ToString();
                objPedidoComplementario.montoSugerido = row["montoSugerido"].ToString();
                objPedidoComplementario.celular = row["celular"].ToString(); 

                lstPedidoComplementario.Add(objPedidoComplementario);

            }

            return lstPedidoComplementario;
        }

        // POST: api/ListaPedidoComplementario
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/ListaPedidoComplementario/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/ListaPedidoComplementario/5
        public void Delete(int id)
        {
        }
    }
}
