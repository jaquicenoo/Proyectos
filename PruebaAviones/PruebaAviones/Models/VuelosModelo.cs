using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PruebaAviones.Models
{
    public class VuelosModelo
    {
        public System.Guid IdRegistro { get; set; }
        public string NumeroVuelo { get; set; }
        public string CiudadOrigen { get; set; }
        public string CiudadDestino { get; set; }
        public System.DateTime Fecha { get; set; }
        public System.TimeSpan HoraSalida { get; set; }
        public System.TimeSpan HoraLlegada { get; set; }
        public string NombreAerolinea { get; set; }
        public bool TipoVuelo { get; set; }
    }
    public class AuxVUelos
    {
        [Required]
        [Display(Name ="Numero de vuelo",Description ="ingrese el numero de vuelo")]
        public string NumeroVuelo { get; set; }
        [Required]
        [Display(Name = "Ciudad de origen", Description = "ingrese la ciudad de origen del vuelo")]
        public List<SelectListItem> CiudadesOrigen { get; set; }
        public string IdciudadOrigen { get; set; }
        [Required]
        [Display(Name = "Ciudad de destino", Description = "ingrese la ciudad de destino del vuelo")]      
        public List<SelectListItem> CiudadesDestino { get; set; }
        public string IdCiudadesDestino { get; set; }
        [Required]
        [Display(Name = "Fecha", Description = "ingrese la fecha del vuelo")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:yyyy-MM-dd}",ApplyFormatInEditMode =true),]
        public System.DateTime Fecha { get; set; }
        [Display(Name = "Hora de salida", Description = "ingrese la Hora de salida del vuelo")]
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:hh\\:mm}", ApplyFormatInEditMode =true)]
        public System.TimeSpan HoraSalida { get; set; }
        [Display(Name = "Hora de llegada", Description = "ingrese la Hora de llegada del vuelo")]
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:hh\\:mm}", ApplyFormatInEditMode = true)]
        public System.TimeSpan HoraLlegada { get; set; }
        [Required]
        [Display(Name = "Aerolinea", Description = "ingrese la Aerolinea del vuelo")]
        public List<SelectListItem> Aerolinea { get; set; }
        public string IdAerolinea { get; set; }
        [Required]
        [Display(Name = "Es un Vuelos entrante?", Description = "indique marcando la casilla si el vuelo es entrante")]
        public bool TipoVuelo { get; set; }

    }
    public class Ciudad
    {
        public System.Guid IdCiudad { get; set; }
        public string NombreCiudad { get; set; }
    }
    public class Aerolinea
    {
        public System.Guid IdAerolinea { get; set; }
        public string NombreAerolinea { get; set; }
    }
}