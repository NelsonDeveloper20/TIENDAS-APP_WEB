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
    public class ListaClienteController : ApiController
    {
        // GET: api/ListaCliente
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/ListaCliente/5
        public List<Cliente> Get(String idUsuario,String CodigoTxt)
        {
            List<Cliente> lstCliente = new List<Cliente>();

            Db obj = new Db();
            DataTable dt = new DataTable();
            dt = obj.ListaClientesRuta(idUsuario,CodigoTxt);


            foreach (DataRow row in dt.Rows)
            {
                Cliente objCliente = new Cliente();
                objCliente.CodigoTxt = row["CodigoTxt"].ToString();
                objCliente.Nombre = row["Nombre"].ToString();
                objCliente.Paterno = row["Paterno"].ToString();
                objCliente.Materno = row["Materno"].ToString();
                objCliente.Direccion = row["Direccion"].ToString();
                objCliente.Latitud = row["Latitud"].ToString();
                objCliente.Longitud = row["Longitud"].ToString();
                objCliente.DiasVisita = row["DiasVisita"].ToString();
                objCliente.ActivaTotalClientes = row["ActivaTotalClientes"].ToString();
                objCliente.VisitadoHoy = row["VisitadoHoy"].ToString();

                lstCliente.Add(objCliente);

            }

            return lstCliente;
        }

        // POST: api/ListaCliente
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/ListaCliente/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/ListaCliente/5
        public void Delete(int id)
        {
        }
    }
}
