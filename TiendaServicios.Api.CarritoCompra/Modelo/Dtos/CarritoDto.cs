using System;
using System.Collections;
using System.Collections.Generic;

namespace TiendaServicios.Api.CarritoCompra.Modelo.Dtos
{
    public class CarritoDto
    {
        public int CarritoId { get; set; }
        public DateTime? FechaCreacionSesion { get; set; }

        public ICollection<CarritoDetalleDto> ListaProductos { get; set; }
    }
}
