using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TiendaServicios.api.Autor.Aplicacion.Dtos;
using TiendaServicios.api.Autor.Controllers;
using TiendaServicios.api.Autor.Modelo;
using TiendaServicios.api.Autor.Persistencia;

namespace TiendaServicios.api.Autor.Aplicacion
{
    public class ConsultaId
    {
        public class AutorUnico : IRequest<AutorDto>
        {
            public string AutorGuid { get; set; }
        }

        public class Manejador : IRequestHandler<AutorUnico, AutorDto>
        {

            private readonly ContextoAutor _contexto;
            private readonly IMapper _mapper;


            public Manejador(ContextoAutor contexto,IMapper mapper)
            {
                _contexto = contexto;
                _mapper = mapper;
            }
            public async Task<AutorDto> Handle(AutorUnico request, CancellationToken cancellationToken)
            {
                var autor = await _contexto.AutorLibro.FirstOrDefaultAsync(a => a.AutorLibroGuid == request.AutorGuid);
                if (autor == null)
                {
                    throw new Exception("No se encontro el autor");
                }
                return _mapper.Map<AutorDto>(autor);
            }
        }
    }
}
