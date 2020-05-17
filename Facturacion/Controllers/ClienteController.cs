using Business.Areas.Cliente;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Facturacion.Controllers
{
    public class ClienteController : Controller
    {
        // GET: Cliente
        [HttpGet]
        public ActionResult Index()
        {
            ClienteAPIController cliente = new ClienteAPIController();
            var list = cliente.ConsultarClientes();
            return View(list);
        }

      
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ClienteDTO clienteDTO)
        {
            ClienteDTO cliente = new ClienteDTO();
            try
            {
                ClienteBusiness clienteBusiness = new ClienteBusiness();
                cliente = clienteBusiness.CreateCliente(clienteDTO);
            }
            catch (DataException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return Redirect("~/Cliente/");
        }

        public ActionResult Update(int Id)
        {
            ClienteDTO cliente = new ClienteDTO();
            ClienteBusiness clienteBusiness = new ClienteBusiness();
            cliente = clienteBusiness.GetClienteById(Id);

            return View(cliente);
        }

        [HttpPost]
        public ActionResult Update(ClienteDTO clienteDTO)
        {
            ClienteDTO cliente = new ClienteDTO();
            try
            {
                ClienteBusiness clienteBusiness = new ClienteBusiness();
                cliente = clienteBusiness.UpdateCliente(clienteDTO);
            }
            catch (DataException dex)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return Redirect("~/Cliente/");
        }

        //Eliminar cliente
        public ActionResult Delete(int Id)
        {
            ClienteBusiness clienteBusiness = new ClienteBusiness();
            int IdCliente = clienteBusiness.DeleteCliente(Id);

            return Redirect("~/Cliente/");
        }

    }
}