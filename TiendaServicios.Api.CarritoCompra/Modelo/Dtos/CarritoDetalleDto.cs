﻿using System;

namespace TiendaServicios.Api.CarritoCompra.Modelo.Dtos
{
    public class CarritoDetalleDto
    {
        public Guid? LibroId { get; set; }
        public string TituloLibro { get; set; }

        public string AutorLibro { get; set; }

        public DateTime? FechaPublicacion { get; set; }
    }
}
