using AutoMapper;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Areas.Producto
{
    public class ProductoBusiness
    {
        //Listar productos
        public List<ProductoDTO> GetListProducto()
        {
            List<ProductoDTO> productoDTOs = new List<ProductoDTO>();

            using (FacturacionEntities db = new FacturacionEntities())
            {
                productoDTOs = (from d in db.Producto
                               select new ProductoDTO
                               {
                                   Id_Producto = d.Id_Producto,
                                   Nombre = d.Nombre,
                                   Descripcion = d.Descripcion,
                                   Precio = d.Precio,
                                   Stock = d.Stock
                               }).ToList();


            };
            return productoDTOs;
        }

        //Crear productos
        public ProductoDTO CreateProducto(ProductoDTO productoDTO)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ProductoDTO, DataAccess.Producto>();
            });
            IMapper iMapper = config.CreateMapper();
            var destination = iMapper.Map<ProductoDTO, DataAccess.Producto>(productoDTO);


            using (FacturacionEntities db = new FacturacionEntities())
            {
                db.Producto.Add(destination);
                db.SaveChanges();

            };
            productoDTO.Id_Producto = destination.Id_Producto;
            return productoDTO;
        }

        //Actualizar producto
        public ProductoDTO UpdateProducto(ProductoDTO productoDTO)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ProductoDTO, DataAccess.Producto>();
            });
            IMapper iMapper = config.CreateMapper();
            var destination = iMapper.Map<ProductoDTO, DataAccess.Producto>(productoDTO);

            using (FacturacionEntities db = new FacturacionEntities())
            {
                if (destination.Id_Producto != 0)
                {
                    var model = db.Producto.Find(destination.Id_Producto);
                    model.Nombre = productoDTO.Nombre;
                    model.Descripcion = productoDTO.Descripcion;
                    model.Precio = productoDTO.Precio;
                    model.Stock = productoDTO.Stock;
                    db.Entry(model).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }

            };

            return productoDTO;
        }

        public ProductoDTO GetProdutoById(int Id)
        {
            ProductoDTO productoDTO = new ProductoDTO();
            using (FacturacionEntities db = new FacturacionEntities())
            {
                var obj = db.Producto.Find(Id);
                productoDTO.Id_Producto = obj.Id_Producto;
                productoDTO.Nombre = obj.Nombre;
                productoDTO.Descripcion = obj.Descripcion;
                productoDTO.Precio = obj.Precio;
                productoDTO.Stock = obj.Stock;
            }

            return productoDTO;
        }

        public int DeleteProducto(int Id)
        {

            using (FacturacionEntities db = new FacturacionEntities())
            {
                var model = db.Producto.Find(Id);
                db.Producto.Remove(model);
                db.SaveChanges();


            };

            return Id;
        }

        public List<ProductoDTO> GetListProductoByExist()
        {
            List<ProductoDTO> productoDTOs = new List<ProductoDTO>();

            using (FacturacionEntities db = new FacturacionEntities())
            {
                productoDTOs = (from d in db.Producto
                                select new ProductoDTO
                                {
                                    Id_Producto = d.Id_Producto,
                                    Nombre = d.Nombre,
                                    Descripcion = d.Descripcion,
                                    Precio = d.Precio,
                                    Stock = d.Stock
                                }).Where(x => x.Stock <= 5).ToList();


            };
            return productoDTOs;
        }

        public List<FacturaDetalleProducto> GetListProductosVendidos()
        {
            List<FacturaDetalleProducto> productoDTOs = new List<FacturaDetalleProducto>();

            using (FacturacionEntities db = new FacturacionEntities())
            {
                var start = new DateTime(2000, 1, 1);
                var end = new DateTime(2000, 12, 31);
                productoDTOs = (from d in db.Detalle_Factura
                                join p in db.Producto on d.Fk_Producto equals p.Id_Producto
                                join f in db.Factura on d.Fk_Factura equals f.Id_Factura
                                where f.Fecha >= start && f.Fecha <= end
                                group p by new { p.Id_Producto, p.Nombre } into g
                                //let sumaTotal = (g.Sum(n => n.Precio))
                                select new FacturaDetalleProducto
                                {
                                    Id_Producto =  g.Key.Id_Producto,
                                    Nombre = g.Key.Nombre,
                                    Precio = g.Sum (x => x.Precio),
                                   

                               }).ToList() ;


            };
            return productoDTOs;
        }




    }
}
