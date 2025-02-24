﻿using System;

namespace TiendaServicios.Api.CarritoCompra.Modelo.RemoteModel
{
    public class LibroRemoto
    {
        public Guid? LibreriaMateriaId { get; set; }

        public string Titulo { get; set; }
        public DateTime? FechaPublicacion { get; set; }

        public Guid? AutorLibro { get; set; }
    }
}
