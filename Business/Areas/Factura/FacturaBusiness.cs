using AutoMapper;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Areas.Factura
{
    public class FacturaBusiness
    {
        //Listar detalle factura
        public List<FacturaDTO> GetListFactura()
        {
            List<FacturaDTO> facturaDTOs = new List<FacturaDTO>();

            using (FacturacionEntities db = new FacturacionEntities())
            {
                facturaDTOs = (from d in db.Factura
                                select new FacturaDTO
                                {
                                    Id_Factura = d.Id_Factura,
                                    Fecha = d.Fecha,
                                    Fk_Cliente = d.Fk_Cliente
                                }).ToList();


            };
            return facturaDTOs;
        }

        //Crear detalle factura
        public FacturaDTO CreateFactura(FacturaDTO facturaDTO)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<FacturaDTO, DataAccess.Factura>();
            });
            IMapper iMapper = config.CreateMapper();
            var destination = iMapper.Map<FacturaDTO, DataAccess.Factura>(facturaDTO);


            using (FacturacionEntities db = new FacturacionEntities())
            {
                db.Factura.Add(destination);
                db.SaveChanges();

            };
            facturaDTO.Id_Factura = destination.Id_Factura;
            return facturaDTO;
        }

        ////Actualizar producto
        //public FacturaDTO UpdateDetalleFactura(FacturaDTO facturaDTO)
        //{
        //    var config = new MapperConfiguration(cfg =>
        //    {
        //        cfg.CreateMap<FacturaDTO, DataAccess.Factura>();
        //    });
        //    IMapper iMapper = config.CreateMapper();
        //    var destination = iMapper.Map<FacturaDTO, DataAccess.Factura>(facturaDTO);

        //    using (FacturacionEntities db = new FacturacionEntities())
        //    {
        //        if (destination.Id_Factura != 0)
        //        {
        //            var model = db.Detalle_Factura.Find(destination.Id_Factura);
        //            model. = detalleFacturaDTO.Cantidad;
        //            model.Precio = detalleFacturaDTO.Precio;
        //            db.Entry(model).State = System.Data.Entity.EntityState.Modified;
        //            db.SaveChanges();
        //        }

        //    };

        //    return detalleFacturaDTO;
        //}

        public FacturaDTO GetFacturaById(int Id)
        {
            FacturaDTO detalleFacturaDTO = new FacturaDTO();
            using (FacturacionEntities db = new FacturacionEntities())
            {
                var obj = db.Factura.Find(Id);
                detalleFacturaDTO.Id_Factura = obj.Id_Factura;
                detalleFacturaDTO.Fecha = obj.Fecha;
                detalleFacturaDTO.Fk_Cliente = obj.Fk_Cliente;
            }

            return detalleFacturaDTO;
        }
    }
}
