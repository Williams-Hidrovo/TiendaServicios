using System;
using System.Collections.Generic;

namespace TiendaServicios.api.Autor.Modelo
{
    public class AutorLibro
    {
        public int AutorLibroId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime? FechaNacimiento { get; set; }

        //un Autor va a tener una colleccion de grados academicos
        public ICollection<GradoAcademico> ListaGradoAcademico { get; set; }

        //valor unico desde otros microservicios

        public string AutorLibroGuid { get; set; }

    }
}
