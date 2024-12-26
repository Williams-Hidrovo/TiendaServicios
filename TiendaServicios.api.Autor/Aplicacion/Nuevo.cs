using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;
using System.Threading.Tasks;
using TiendaServicios.api.Autor.Modelo;
using TiendaServicios.api.Autor.Persistencia;

namespace TiendaServicios.api.Autor.Aplicacion
{
    public class Nuevo
    {

        //esta clase es la que se comunicara con el controller
        public class Ejecuta : IRequest
        {
            public string Nombre { get; set; }
            public string Apellido { get; set; }
            public DateTime? FechaNacimiento { get; set; }
        }

        public class EjecutaValidacion: AbstractValidator<Ejecuta>
        {
            public EjecutaValidacion()
            {
                RuleFor(x => x.Nombre).NotEmpty();
                RuleFor(x => x.Apellido).NotEmpty();

            }
        }


        //implementa la logica para hacer las inserciones a la base de datos
        public class Manejador : IRequestHandler<Ejecuta>
        {

            //crear referencia al contexto
            public readonly ContextoAutor _contexto;

            public Manejador(ContextoAutor contexto)
            {
                _contexto = contexto;

            }

            public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var autorLibro = new AutorLibro
                {
                    Nombre = request.Nombre,
                    Apellido = request.Apellido,
                    FechaNacimiento = request.FechaNacimiento,
                    AutorLibroGuid = Guid.NewGuid().ToString()

                };

                //quiero insertar un nuevo autor
                _contexto.AutorLibro.Add(autorLibro);
                var valor=await _contexto.SaveChangesAsync();
                if (valor > 0)
                {
                    return Unit.Value;
                }
                throw new Exception("No se pudo insertar el autor");

            }
        }
        
    }
}
