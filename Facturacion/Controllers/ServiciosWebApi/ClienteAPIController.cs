using Business.Areas.Cliente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Facturacion.Controllers
{
    public class ClienteAPIController : ApiController
    {
        [HttpGet]
        public List<ClienteDTO> ConsultarClientes()
        {
            List<ClienteDTO> lista = new List<ClienteDTO>();
            ClienteBusiness clienteBusiness = new ClienteBusiness();
            lista = clienteBusiness.GetListCliente();

            return lista;
        }

        public List<ClienteFacturaDTO> FacturasByFecha()
        {
            ClienteBusiness cliente = new ClienteBusiness();
            var list = cliente.GetListClientesByCompras();
            return list;
        }

    }
}
