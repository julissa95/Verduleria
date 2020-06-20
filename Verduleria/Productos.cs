using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Verduleria
{
   public class Productos
    {
        public string IdProducto { get; set; }
        public double precio { get; set; }
        public string descripcion { get; set; }
        public string origen { get; set; }
        public DateTime fechaViencimiento { get; set; }
        public int cantidad { get; set; }
    }
}
