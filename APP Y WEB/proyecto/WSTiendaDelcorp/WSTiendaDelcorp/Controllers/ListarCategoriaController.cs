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
    public class ListarCategoriaController : ApiController
    {
        // GET: api/ListarCategoria
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/ListarCategoria/5
        public List<Categoria> Get(String idUsuario,String CodigoTxt)
        {
            List<Categoria> lstCategoria = new List<Categoria>();

            Db obj = new Db();
            DataTable dt = new DataTable();
            dt = obj.ListarCategoriasProductos(idUsuario,CodigoTxt);


            foreach (DataRow row in dt.Rows)
            {
                Categoria objCategoria = new Categoria();
                objCategoria.IdCategoria = row["IdCategoria"].ToString(); 
                objCategoria.IdUp = row["IdUp"].ToString(); 
                objCategoria.Stock = row["Stock"].ToString();
                objCategoria.Nombre = row["Nombre"].ToString();
                objCategoria.Descripcion = row["Descripcion"].ToString();
                objCategoria.Precio = row["Precio"].ToString();
                objCategoria.Peso = row["Peso"].ToString();
                objCategoria.Imagen = row["Imagen"].ToString();

                lstCategoria.Add(objCategoria);

            }

            return lstCategoria;
        }

        // POST: api/ListarCategoria
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/ListarCategoria/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/ListarCategoria/5
        public void Delete(int id)
        {
        }
    }
}
