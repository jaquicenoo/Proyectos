using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PruebaAviones.Models
{
    public class VuelosModelo
    {
        public string NumeroVuelo { get; set; }
        public string CiudadOrigen { get; set; }
        public string CiudadDestino { get; set; }
        public System.DateTime Fecha { get; set; }
        public System.TimeSpan HoraSalida { get; set; }
        public System.TimeSpan HoraLlegada { get; set; }
        public string NombreAerolinea { get; set; }
    }
}