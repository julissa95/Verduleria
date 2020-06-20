using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Verduleria
{
   public class Ventas
    {
        public int id { get; set; }
        public int cantidad { get; set; }
        public double monto { get; set; }
        public string tipoVenta { get; set; }
        public string Idcliente { get; set; }
        public DateTime fecha { get; set; }
        public string idProducto { get; set; }
        public string descuento { get; set; }

    }
}

