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
    public class ListaProductoV2Controller : ApiController
    {
        // GET: api/ListaProductoV2
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/ListaProductoV2/5
        public List<ProductoV2> Get(String idUsuario, String CodigoTxt)
        {
            List<ProductoV2> lstProducto = new List<ProductoV2>();

            Db obj = new Db();
            DataTable dt = new DataTable();
            dt = obj.ListarProductosV2(idUsuario, CodigoTxt);


            foreach (DataRow row in dt.Rows)
            {
                ProductoV2 objProducto = new ProductoV2();
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
                objProducto.visible = row["visible"].ToString();

                lstProducto.Add(objProducto);

            }

            return lstProducto;
        }

        // POST: api/ListaProductoV2
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/ListaProductoV2/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/ListaProductoV2/5
        public void Delete(int id)
        {
        }
    }
}
