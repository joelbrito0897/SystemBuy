using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ventas.Models
{
    public class FacturasViewModel
    {
        public Factura factura { get; set; }
        public Customer Customer { get; set; }
    }
}