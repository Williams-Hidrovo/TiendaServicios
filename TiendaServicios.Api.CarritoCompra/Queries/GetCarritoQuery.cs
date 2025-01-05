using MediatR;
using TiendaServicios.Api.CarritoCompra.Modelo.Dtos;

namespace TiendaServicios.Api.CarritoCompra.Queries
{
    public class GetCarritoQuery:IRequest<CarritoDto>
    {
        public int CarritoSesionId { get; set; }
    }
}
