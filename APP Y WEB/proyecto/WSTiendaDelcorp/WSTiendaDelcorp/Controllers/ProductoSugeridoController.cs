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
    public class ProductoSugeridoController : ApiController
    {
        // GET: api/ProductoSugerido
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/ProductoSugerido/5
        public List<ProductoSugerido> Get(String idUsuario)
        {
            List<ProductoSugerido> lstProductoSugerido = new List<ProductoSugerido>();

            Db obj = new Db();
            DataTable dt = new DataTable();
            dt = obj.ListarProductoSugerido(idUsuario);
             
            foreach (DataRow row in dt.Rows)
            {
                ProductoSugerido objProductoSugerido = new ProductoSugerido();
                objProductoSugerido.IdProducto = row["IdProducto"].ToString();
                objProductoSugerido.IdCategoria = row["IdCategoria"].ToString();
                objProductoSugerido.IdCategoriaPadre = row["IdCategoriaPadre"].ToString();
                objProductoSugerido.IdFabricante = row["IdFabricante"].ToString();
                objProductoSugerido.NombrePro = row["NombrePro"].ToString();
                objProductoSugerido.Descripcion = row["Descripcion"].ToString();
                objProductoSugerido.Precio = row["Precio"].ToString();
                objProductoSugerido.Peso = row["Peso"].ToString();
                objProductoSugerido.Imagen = row["Imagen"].ToString(); 
                objProductoSugerido.IdAlmacen = row["IdAlmacen"].ToString();
                objProductoSugerido.Stock = row["Stock"].ToString();
                objProductoSugerido.CantidadUnidades = row["CantidadUnidades"].ToString();
                objProductoSugerido.NumeroOrdenesOrdenes = row["NumeroOrdenesOrdenes"].ToString();
                objProductoSugerido.CantidadSugerida = row["CantidadSugerida"].ToString();
                objProductoSugerido.PorcentajeAdicional = row["PorcentajeAdicional"].ToString();

                lstProductoSugerido.Add(objProductoSugerido);

            }

            return lstProductoSugerido;
        }

        // POST: api/ProductoSugerido
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/ProductoSugerido/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/ProductoSugerido/5
        public void Delete(int id)
        {
        }
    }
}
