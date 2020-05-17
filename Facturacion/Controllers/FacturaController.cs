using Business.Areas.Cliente;
using Business.Areas.Factura;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Facturacion.Controllers
{
    public class FacturaController : Controller
    {
        // GET: Factura
        [HttpGet]
        public ActionResult Index()
        {
            FacturaBusiness factura = new FacturaBusiness();
            var list = factura.GetListFactura();
            return View(list);
        }

        public ActionResult Create()
        {
            ClienteBusiness business = new ClienteBusiness();
            List<ClienteDTO> clientes = new List<ClienteDTO>();
            clientes = business.GetClientesWithIdAndDescription();
            List<SelectListItem> lst = new List<SelectListItem>();

            foreach (var item in clientes)
            {
                SelectListItem select = new SelectListItem();
                select.Text = item.Nombre + item.Apellido;
                select.Value = item.Identificacion_Cliente.ToString();
                lst.Add(select);
            }
            ViewBag.Opciones = lst;
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FacturaDTO facturaDTO)
        {
            FacturaDTO factura = new FacturaDTO();
            try
            {
                FacturaBusiness facturaBusiness = new FacturaBusiness();
                factura = facturaBusiness.CreateFactura(facturaDTO);
              

            }
            catch (DataException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return RedirectToAction("Create", "DetalleFactura", new { id = factura.Id_Factura });
        }

        public ActionResult FacturasByFecha()
        {
            ClienteAPIController cliente = new ClienteAPIController();
            var list = cliente.FacturasByFecha();
            return View(list);
        }

    }
}