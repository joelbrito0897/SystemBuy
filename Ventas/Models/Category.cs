using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ventas.Models
{
    public class Category
    {
        public int ID { get; set; }

        [Required]
        [Display(Name = "Nombre")]

        public string Name { get; set; }
        [Required]
        [Display(Name = "Desccripcion")]
        [DataType(DataType.MultilineText)]
        [StringLength(200,MinimumLength =20,ErrorMessage ="El campo {0} debe estar entre {2} y {1} caracteres.")]
        public string Description { get; set; }
    }
}