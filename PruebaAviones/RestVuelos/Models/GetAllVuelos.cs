//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RestVuelos.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class GetAllVuelos
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
        public string NombreEstado { get; set; }
    }
}
