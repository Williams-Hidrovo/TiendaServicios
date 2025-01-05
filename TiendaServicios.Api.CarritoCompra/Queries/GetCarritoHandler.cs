using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TiendaServicios.Api.CarritoCompra.Modelo.Dtos;
using TiendaServicios.Api.CarritoCompra.Persistencia;
using TiendaServicios.Api.CarritoCompra.RemoteInterface;

namespace TiendaServicios.Api.CarritoCompra.Queries
{
    public class GetCarritoHandler : IRequestHandler<GetCarritoQuery, CarritoDto>
    {
        private readonly CarritoContexto _contexto;
        private readonly ILibrosService _libroService;
        //no olvidar configurar la clase ILibrosService en startup para la inyeccion de dependencias
        public GetCarritoHandler(CarritoContexto contexto, ILibrosService libroservice)
        {
            _contexto = contexto;
            _libroService = libroservice;
        }
        public async Task<CarritoDto> Handle(GetCarritoQuery request, CancellationToken cancellationToken)
        {
            //opteniendo el carrito
            var carritoSesion = await _contexto.CarritoSesion.FirstOrDefaultAsync(c => c.CarritoSesionId == request.CarritoSesionId);

            //validar que no sea null o no se encuentre esta carritoSesion
            if (carritoSesion == null)
            {
                throw new KeyNotFoundException($"No se encontró un carrito con el ID {request.CarritoSesionId}.");
            }
            //lista de productos IDS de los libros no el detalle
            var carritoSesionDetalle1 = await _contexto.CarritoSesionDetalle.Where(c => c.CarritoSesionId == request.CarritoSesionId).ToListAsync();

            var listaCarritoDto = new List<CarritoDetalleDto>();

            foreach (var libro in carritoSesionDetalle1)
            {
                var response=await _libroService.GetLibro(new Guid(libro.ProductoSeleccionado));
                if (response.resultado)
                {
                    var objetoLibro = response.libro;
                    var carritoDetalle = new CarritoDetalleDto
                    {
                        TituloLibro = objetoLibro.Titulo,
                        FechaPublicacion=objetoLibro.FechaPublicacion,
                        LibroId=objetoLibro.LibreriaMateriaId

                    };
                    listaCarritoDto.Add(carritoDetalle);
                }
               
            }
            var carritoSesionDto = new CarritoDto
            {
                CarritoId=carritoSesion.CarritoSesionId,
                FechaCreacionSesion=carritoSesion.FechaCreacion,
                ListaProductos=listaCarritoDto
            };

            return carritoSesionDto;

           

        }
    }
}
