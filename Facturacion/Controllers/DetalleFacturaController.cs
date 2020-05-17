using Business.Areas.DetalleFactura;
using Business.Areas.Producto;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Facturacion.Controllers
{
    public class DetalleFacturaController : Controller
    {
        // GET: DetalleFactura
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create(int id)
        {
            ProductoBusiness business = new ProductoBusiness();
            List<ProductoDTO> clientes = new List<ProductoDTO>();
            clientes = business.GetListProducto();
            List<SelectListItem> lst = new List<SelectListItem>();

            foreach (var item in clientes)
            {
                SelectListItem select = new SelectListItem();
                select.Text = item.Nombre;
                select.Value = item.Id_Producto.ToString();
                lst.Add(select);
            }
            ViewBag.Opciones = lst;
            DetalleFacturaDTO detalleFacturaDTO = new DetalleFacturaDTO();
            detalleFacturaDTO.Fk_Factura = id;
            return View(detalleFacturaDTO);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DetalleFacturaDTO detallleFacturaDTO)
        {
            DetalleFacturaDTO factura = new DetalleFacturaDTO();
            try
            {
                DetalleFacturaBusiness facturaBusiness = new DetalleFacturaBusiness();
                factura = facturaBusiness.CreateDetalleFactura(detallleFacturaDTO);


            }
            catch (DataException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return Redirect("~/Factura/");
        }
    }
}