using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ventas.Models
{
    public class Product
    {
        public int ID { get; set; }

        [Required]
        [Display(Name = "Nombre")]

        public string Name { get; set; }
        [Required]
        [Display(Name = "Precio")]
        [DisplayFormat(DataFormatString ="{0:$##,#}")]
        public double Price { get; set; }
        [Display(Name = "Categoria")]
        [Required]
        
        public int CategoryID { get; set; }
        [Display(Name = "Categoria")]
        public virtual Category Category { get; set; }

        public string Image { get; set; }
    }
}