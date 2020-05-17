using Business.Areas.Producto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPI.Controllers
{
    public class ProductosController : ApiController
    {
        [HttpGet]
        public List<ProductoDTO> ListaPrecioProductos()
        {
            List<ProductoDTO> lista = new List<ProductoDTO>();
            ProductoBusiness productoBusiness = new ProductoBusiness();
            lista = productoBusiness.GetListProducto();

            return lista;
        }
        [HttpGet]
        public List<ProductoDTO> ConsultaProductosExistencia()
        {
            List<ProductoDTO> listaExistencia = new List<ProductoDTO>();
            ProductoBusiness productoBusiness = new ProductoBusiness();
            listaExistencia = productoBusiness.GetListProductoByExist();

            return listaExistencia;
        }
    }
}
