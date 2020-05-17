using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Areas.DetalleFactura
{
   public  class DetalleFacturaDTO
    {
        public int Id_Detalle_Factura { get; set; }
        public int Precio { get; set; }
        public int Cantidad { get; set; }
        public int Fk_Factura { get; set; }
        public int Fk_Producto { get; set; }
    }
}
