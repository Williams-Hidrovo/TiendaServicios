using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TiendaServicios.Api.CarritoCompra.Commands;
using TiendaServicios.Api.CarritoCompra.Modelo.Dtos;
using TiendaServicios.Api.CarritoCompra.Queries;

namespace TiendaServicios.Api.CarritoCompra.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarritoComprasController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CarritoComprasController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<int>> CreateCarritoCompra([FromBody] CreateCarritoCompraCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CarritoDto>> GetCarrito(int id)
        {
            var carrito = await _mediator.Send(new GetCarritoQuery { CarritoSesionId = id });

            if (carrito == null)
            {
                return NotFound($"No se encontró un carrito con el ID {id}.");
            }

            return Ok(carrito);
        }
    }
}
