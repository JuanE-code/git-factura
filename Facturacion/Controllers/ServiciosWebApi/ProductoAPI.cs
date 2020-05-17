using Business.Areas.DetalleFactura;
using Business.Areas.Producto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Facturacion.Controllers.ServiciosWebApi
{
    public class ProductoAPI
    {
        public List<ProductoDTO> GetListProducto()
        {
            ProductoBusiness productoBusiness = new ProductoBusiness();
            var list = productoBusiness.GetListProducto();

            return list;
        }

        public List<FacturaDetalleProducto> GetListProductosVendidos()
        {
            ProductoBusiness productoBusiness = new ProductoBusiness();
            var list = productoBusiness.GetListProductosVendidos();

            return list;
        }
    }
}