using System;

namespace TiendaServicios.Api.Gateway.LibroRemote
{
    public class LibroModeloRemote
    {
        public Guid? LibreriaMateriaId { get; set; }

        public string Titulo { get; set; }
        public DateTime? FechaPublicacion { get; set; }

        public Guid? AutorLibro { get; set; }

        public AutorModeloRemote AutorData {get;set;}
    }
}
