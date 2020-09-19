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
    public class ListaProductoController : ApiController
    {
        // GET: api/ListaProducto
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/ListaProducto/5
        public List<Producto> Get(String idUsuario,String CodigoTxt)
        {
            List<Producto> lstProducto = new List<Producto>();

            Db obj = new Db();
            DataTable dt = new DataTable();
            dt = obj.ListarProductos(idUsuario, CodigoTxt);


            foreach (DataRow row in dt.Rows)
            {
                Producto objProducto = new Producto();
                objProducto.IdProductoCategoria = row["IdProductoCategoria"].ToString();
                objProducto.IdProductoTxt = row["IdProductoTxt"].ToString();
                objProducto.IdCategoria = row["IdCategoria"].ToString();
                objProducto.IdCategoriaPadre = row["IdCategoriaPadre"].ToString();
                objProducto.IdFabricante = row["IdFabricante"].ToString();
                objProducto.NombrePro = row["NombrePro"].ToString();
                objProducto.Descripcion = row["Descripcion"].ToString();
                objProducto.Precio = row["Precio"].ToString();
                objProducto.Peso = row["Peso"].ToString();
                objProducto.Imagen = row["Imagen"].ToString();
                objProducto.IdAlmacen = row["IdAlmacen"].ToString();
                objProducto.Stock = row["Stock"].ToString();

                lstProducto.Add(objProducto);

            }

            return lstProducto;
        }

        // POST: api/ListaProducto
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/ListaProducto/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/ListaProducto/5
        public void Delete(int id)
        {
        }
    }
}
