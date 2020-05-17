using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Areas.Cliente
{
    public class ClienteDTO
    {
        
        public int Identificacion_Cliente { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Edad { get; set; }
        public int Telefono { get; set; }
    }
}
