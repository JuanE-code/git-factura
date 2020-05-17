using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace Business.Areas.Cliente
{
    public class ClienteBusiness
    {

        //Listar clientes
        public List<ClienteDTO> GetListCliente()
        {
            List<ClienteDTO> clienteDTOs = new List<ClienteDTO>();

            using (FacturacionEntities db = new FacturacionEntities())
            {
                clienteDTOs = (from d in db.Cliente
                               select new ClienteDTO
                               {
                                   Identificacion_Cliente = d.Identificacion_Cliente,
                                   Nombre = d.Nombre,
                                   Apellido = d.Apellido,
                                   Telefono = d.Telefono,
                                   Edad = d.Edad
                               }).ToList();


            };
            return clienteDTOs;
        }
        
        //Crear clientes
        public ClienteDTO CreateCliente(ClienteDTO clienteDTO)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ClienteDTO, DataAccess.Cliente>();
            });
            IMapper iMapper = config.CreateMapper();
            var destination = iMapper.Map<ClienteDTO, DataAccess.Cliente>(clienteDTO);


            using (FacturacionEntities db = new FacturacionEntities())
            {
                db.Cliente.Add(destination);
                db.SaveChanges();

            };
            clienteDTO.Identificacion_Cliente = destination.Identificacion_Cliente;
            return clienteDTO;
        }

        public ClienteDTO UpdateCliente(ClienteDTO clienteDTO)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ClienteDTO, DataAccess.Cliente>();
            });
            IMapper iMapper = config.CreateMapper();
            var destination = iMapper.Map<ClienteDTO, DataAccess.Cliente>(clienteDTO);

            using (FacturacionEntities db = new FacturacionEntities())
            {
                if (destination.Identificacion_Cliente != 0)
                {
                    var model = db.Cliente.Find(destination.Identificacion_Cliente);
                    model.Nombre = clienteDTO.Nombre;
                    model.Apellido = clienteDTO.Apellido;
                    model.Telefono = clienteDTO.Telefono;
                    model.Edad = clienteDTO.Edad;
                    db.Entry(model).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }

            };

            return clienteDTO;
        }

        public ClienteDTO GetClienteById(int Id)
        {
            ClienteDTO clienteDTO = new ClienteDTO();
            using (FacturacionEntities db = new FacturacionEntities())
            {
                var obj = db.Cliente.Find(Id);
                clienteDTO.Identificacion_Cliente = obj.Identificacion_Cliente;
                clienteDTO.Nombre = obj.Nombre;
                clienteDTO.Apellido = obj.Apellido;
                clienteDTO.Telefono = obj.Telefono;
                clienteDTO.Edad = obj.Edad;
            }

            return clienteDTO;
        }

        public int DeleteCliente(int Id)
        {

            using (FacturacionEntities db = new FacturacionEntities())
            {
                var model = db.Cliente.Find(Id);
                db.Cliente.Remove(model);
                db.SaveChanges();


            };

            return Id;
        }

        public List<ClienteDTO> GetClientesWithIdAndDescription()
        {
            List<ClienteDTO> clienteDTOs = new List<ClienteDTO>();

            using (FacturacionEntities db = new FacturacionEntities())
            {
                clienteDTOs = (from d in db.Cliente
                               select new ClienteDTO
                               {
                                   Identificacion_Cliente = d.Identificacion_Cliente,
                                   Nombre = d.Nombre,
                                   Apellido = d.Apellido
                               }).ToList();


            };
            return clienteDTOs;
        }

        public List<ClienteFacturaDTO> GetListClientesByCompras()
        {
            List<ClienteFacturaDTO> productoDTOs = new List<ClienteFacturaDTO>();

            using (FacturacionEntities db = new FacturacionEntities())
            {
                var start = new DateTime(2000, 1, 1);
                var end = new DateTime(2000, 5, 25);
                productoDTOs = (from d in db.Cliente
                                join f in db.Factura on d.Identificacion_Cliente equals f.Cliente.Identificacion_Cliente 
                                select new ClienteFacturaDTO
                                {
                                    Identificacion_Cliente = d.Identificacion_Cliente,
                                    Nombre = d.Nombre,
                                    Apellido = d.Apellido,
                                    Edad = d.Edad,
                                    Telefono = d.Telefono,
                                    Id_Factura = f.Id_Factura,
                                    Fecha = f.Fecha,

                                }).Where(x => x.Edad <= 35 && x.Fecha >= start && x.Fecha <= end).ToList();


            };
            return productoDTOs;
        }
    }
}
