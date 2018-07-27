using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PruebaAviones.Models
{
    public class UsuariosModelo
    {
        [Key]
        [Required]
        public Guid IdUsuarios { get; set; }
        [Required]
        [Display(Name ="Usuario")]
        public string usuario { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name ="Password")]
        public string Contraseña { get; set; }
    }
}