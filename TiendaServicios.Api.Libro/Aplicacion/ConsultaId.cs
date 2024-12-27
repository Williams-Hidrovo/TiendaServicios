using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;
using TiendaServicios.Api.Libro.Modelo.Dtos;
using TiendaServicios.Api.Libro.Persistencia;

namespace TiendaServicios.Api.Libro.Aplicacion
{
    public class ConsultaId
    {
        public class Ejecuta:IRequest<LibroMaterialDto>
        {
            public Guid AutorGuid { get; set; }
        }

        public class Modifica : IRequestHandler<Ejecuta, LibroMaterialDto>
        {
            private readonly ContextoLibreria _contexto;
            private readonly IMapper _mapper;

            public Modifica(ContextoLibreria contexto, IMapper mapper)
            {
                _contexto = contexto;
                _mapper = mapper;
            }
            public async Task<LibroMaterialDto> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var libro = await _contexto.LibreriaMaterial.FirstOrDefaultAsync(x => x.LibreriaMateriaId == request.AutorGuid);

                if (libro == null)
                {
                    throw new Exception("Libro no encontrado");
                }
                return _mapper.Map<LibroMaterialDto>(libro);
            }
        }
    }
}
