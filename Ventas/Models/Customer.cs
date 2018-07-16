using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ventas.Models
{
    public class Customer
    {
        public int ID { get; set; }
        [Required]
        [Display(Name ="Nombre")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Apellido")]
        public string LastName { get; set; }
        [Required]
        [EmailAddress(ErrorMessage ="El {0} no es valido")]
        [Display(Name = "Correo")]
        public string Email { get; set; }
        [Required]
        [Display(Name = "Direccion")]
        [DataType(DataType.MultilineText)]
        public string Addres { get; set; }
        [Required]
        [Display(Name = "Numero de telefono")]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }
    }
}