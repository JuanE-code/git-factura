using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Areas.Producto
{
    public class FacturaDetalleProducto
    {
        public int Id_Producto { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int Stock { get; set; }
        public int Id_Factura { get; set; }
        public DateTime? Fecha { get; set; }
        public int Fk_Cliente { get; set; }
        public int Id_Detalle_Factura { get; set; }
        public int Precio { get; set; }
        public int Cantidad { get; set; }
        public int Fk_Factura { get; set; }
        public int Fk_Producto { get; set; }
    }
}
