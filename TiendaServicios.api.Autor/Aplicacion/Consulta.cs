using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TiendaServicios.api.Autor.Aplicacion.Dtos;
using TiendaServicios.api.Autor.Modelo;
using TiendaServicios.api.Autor.Persistencia;

namespace TiendaServicios.api.Autor.Aplicacion
{
    public class Consulta
    {
        //IRequest define el tipo de valor que se va a recibir o enviar
        public class ListaAutor : IRequest<List<AutorDto>> { }


        //clase que maneja la logica de la consulta

        //IRequestHandler < clase encargada del request, valor que va a devolver la consulta>
        public class Manejador : IRequestHandler<ListaAutor, List<AutorDto>> {
            private readonly ContextoAutor _contexto;
            private readonly IMapper _mapper;

            public Manejador(ContextoAutor contexto, IMapper mapper)
            {
                _contexto = contexto;
                _mapper = mapper;
            }
            public async Task<List<AutorDto>> Handle(ListaAutor request, CancellationToken cancellationToken)
            {
                var autores =await _contexto.AutorLibro.ToListAsync();
                var autoresDto = _mapper.Map<List<AutorDto>>(autores);
                return autoresDto;
                
            }
        }
    }
}
