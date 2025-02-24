﻿using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TiendaServicios.api.Autor.Aplicacion;
using TiendaServicios.api.Autor.Aplicacion.Dtos;
using TiendaServicios.api.Autor.Modelo;

namespace TiendaServicios.api.Autor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutorController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AutorController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<Unit>> Crear(Nuevo.Ejecuta data)
        {
            return await _mediator.Send(data);

        }

        [HttpGet]
        public async Task<ActionResult<List<AutorDto>>> GetAutores(){
            return await _mediator.Send(new Consulta.ListaAutor());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AutorDto>> GetAutorLibro(string id)
        {
            return await _mediator.Send(new ConsultaId.AutorUnico { AutorGuid=id });
        }



    }
}
