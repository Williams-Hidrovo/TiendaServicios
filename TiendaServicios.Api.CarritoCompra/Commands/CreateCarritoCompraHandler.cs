using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using TiendaServicios.Api.CarritoCompra.Modelo;
using TiendaServicios.Api.CarritoCompra.Persistencia;

namespace TiendaServicios.Api.CarritoCompra.Commands
{
    public class CreateCarritoCompraHandler:IRequestHandler<CreateCarritoCompraCommand,int>
    {
        private readonly CarritoContexto _contexto;

        public CreateCarritoCompraHandler(CarritoContexto contexto)
        {
            _contexto = contexto;
        }

        public async Task<int> Handle(CreateCarritoCompraCommand request, CancellationToken cancellationToken)
        {
            var carritoSesion = new CarritoSesion
            {
                FechaCreacion = request.FechaCreacionSesion,

            };

            _contexto.CarritoSesion.Add(carritoSesion);
            await _contexto.SaveChangesAsync(cancellationToken);
            int id= carritoSesion.CarritoSesionId;

            foreach(var obj in request.ProductoLista)
            {
                var detalleSesion = new CarritoSesionDetalle
                {
                    FechaCreacion=DateTime.Now,
                    CarritoSesionId=id,
                    ProductoSeleccionado=obj
                };

                _contexto.CarritoSesionDetalle.Add(detalleSesion);
            }
            await _contexto.SaveChangesAsync(cancellationToken);
            return id;
        }
    }
}
