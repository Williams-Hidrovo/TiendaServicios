using System.Collections.Generic;
using System;
using TiendaServicios.api.Autor.Modelo;

namespace TiendaServicios.api.Autor.Aplicacion.Dtos
{
    public class AutorDto
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public string AutorLibroGuid { get; set; }
    }
}
