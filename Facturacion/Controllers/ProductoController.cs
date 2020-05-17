using Business.Areas.Producto;
using Facturacion.Controllers.ServiciosWebApi;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Facturacion.Controllers
{
    public class ProductoController : Controller
    {
        // GET: Producto
        public ActionResult Index()
        {
            ProductoAPI productoBusiness = new ProductoAPI();
            var list = productoBusiness.GetListProducto();

            return View(list);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductoDTO productoDTO)
        {
            ProductoDTO producto = new ProductoDTO();
            try
            {
                ProductoBusiness productoBusiness = new ProductoBusiness();
                producto = productoBusiness.CreateProducto(productoDTO);
            }
            catch (DataException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Ocurrio un error en el sistema, comuniquese con el administrador");
            }
            return Redirect("~/Producto/");
        }

        public ActionResult Update(int Id)
        {
            ProductoDTO producto = new ProductoDTO();
            ProductoBusiness productoBusiness = new ProductoBusiness();
            producto = productoBusiness.GetProdutoById(Id);

            return View(producto);
        }

        [HttpPost]
        public ActionResult Update(ProductoDTO productoDTO)
        {
            ProductoDTO producto = new ProductoDTO();
            try
            {
                ProductoBusiness productoBusiness = new ProductoBusiness();
                producto = productoBusiness.UpdateProducto(productoDTO);
            }
            catch (DataException dex)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Ocurrio un error, no se actualizo el producto");
            }
            return Redirect("~/Producto/");
        }

        //Eliminar cliente
        public ActionResult Delete(int Id)
        {
            ProductoBusiness productoBusiness = new ProductoBusiness();
            int IdProducto = productoBusiness.DeleteProducto(Id);

            return Redirect("~/Producto/");
        }

        public ActionResult ConsultaProductosExistencia()
        {
            ProductoBusiness productoBusiness = new ProductoBusiness();
            var list = productoBusiness.GetListProductoByExist();

            return View(list);
        }

        public ActionResult ProductosVendidos()
        {
            ProductoAPI productoBusiness = new ProductoAPI();
            var list = productoBusiness.GetListProductosVendidos();

            return View(list);
        }

    }
}