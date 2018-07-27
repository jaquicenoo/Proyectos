using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestVuelos.Models
{
    public class VuelosModelo
    {
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