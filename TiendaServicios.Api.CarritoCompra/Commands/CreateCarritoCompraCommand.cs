using MediatR;
using System;
using System.Collections.Generic;

namespace TiendaServicios.Api.CarritoCompra.Commands
{
    public class CreateCarritoCompraCommand : IRequest<int>
    {
        public DateTime FechaCreacionSesion { get; set; }
        public List<string> ProductoLista { get; set; }
    }
    
    
}
