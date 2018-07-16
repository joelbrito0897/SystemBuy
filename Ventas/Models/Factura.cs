using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ventas.Models
{
    public class Factura
    {
        public int ID { get; set; }
        [Required]
        public int ClienteID { get; set; }
        [Required]
        public string ClienteName { get; set; }
        [Required]
        public double Itbis { get; set; }
        [Required]
        public double SubTotal { get; set; }
        [Required]
        public double Total { get; set; }


    }
}