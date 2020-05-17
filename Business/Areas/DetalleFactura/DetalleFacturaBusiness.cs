using AutoMapper;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Areas.DetalleFactura
{
    public class DetalleFacturaBusiness
    {
        //Listar detalle factura
        public List<DetalleFacturaDTO> GetListDetalleFactura()
        {
            List<DetalleFacturaDTO> productoDTOs = new List<DetalleFacturaDTO>();

            using (FacturacionEntities db = new FacturacionEntities())
            {
                productoDTOs = (from d in db.Detalle_Factura
                                select new DetalleFacturaDTO
                                {
                                    Id_Detalle_Factura = d.Id_Detalle_Factura,
                                    Precio = d.Precio,
                                    Cantidad = d.Cantidad,
                                    Fk_Factura = d.Fk_Factura,
                                    Fk_Producto = d.Fk_Producto
                                }).ToList();


            };
            return productoDTOs;
        }

        //Crear detalle factura
        public DetalleFacturaDTO CreateDetalleFactura(DetalleFacturaDTO productoDTO)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<DetalleFacturaDTO, DataAccess.Detalle_Factura>();
            });
            IMapper iMapper = config.CreateMapper();
            var destination = iMapper.Map<DetalleFacturaDTO, DataAccess.Detalle_Factura>(productoDTO);


            using (FacturacionEntities db = new FacturacionEntities())
            {
                db.Detalle_Factura.Add(destination);
                db.SaveChanges();

            };
            productoDTO.Id_Detalle_Factura = destination.Id_Detalle_Factura;
            return productoDTO;
        }

        //Actualizar producto
        public DetalleFacturaDTO UpdateDetalleFactura(DetalleFacturaDTO detalleFacturaDTO)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<DetalleFacturaDTO, DataAccess.Producto>();
            });
            IMapper iMapper = config.CreateMapper();
            var destination = iMapper.Map<DetalleFacturaDTO, DataAccess.Detalle_Factura>(detalleFacturaDTO);

            using (FacturacionEntities db = new FacturacionEntities())
            {
                if (destination.Id_Detalle_Factura != 0)
                {
                    var model = db.Detalle_Factura.Find(destination.Id_Detalle_Factura);
                    model.Cantidad = detalleFacturaDTO.Cantidad;
                    model.Precio = detalleFacturaDTO.Precio;
                    db.Entry(model).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }

            };

            return detalleFacturaDTO;
        }

        public DetalleFacturaDTO GetDetalleFacturaById(int Id)
        {
            DetalleFacturaDTO detalleFacturaDTO = new DetalleFacturaDTO();
            using (FacturacionEntities db = new FacturacionEntities())
            {
                var obj = db.Detalle_Factura.Find(Id);
                detalleFacturaDTO.Id_Detalle_Factura = obj.Id_Detalle_Factura;
                detalleFacturaDTO.Precio = obj.Precio;
                detalleFacturaDTO.Cantidad = obj.Cantidad;
                detalleFacturaDTO.Fk_Factura = obj.Fk_Factura;
                detalleFacturaDTO.Fk_Producto = obj.Fk_Producto;
            }

            return detalleFacturaDTO;
        }

        //public int DeleteProducto(int Id)
        //{

        //    using (FacturacionEntities db = new FacturacionEntities())
        //    {
        //        var model = db.Producto.Find(Id);
        //        db.Producto.Remove(model);
        //        db.SaveChanges();


        //    };

        //    return Id;
        //}

        
    }
}
