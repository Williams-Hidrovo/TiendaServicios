using AutoMapper;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using TiendaServicios.Api.Libro.Aplicacion;
using TiendaServicios.Api.Libro.Persistencia;
using Xunit;

namespace TiendaServicios.Api.Libro.Tests
{
    
    public class LibrosServicesTest
    {
        [Fact]
        public void GetLibros()
        {
            //que metodo dentro de mi microservice libro se esta encargando 
            //de realizar la consulta de libros de la base de datos

            //1. emular a la instancia de entity framework core
            //para emular las acciones y eventos de un objeto en ambiente de unit test
            //utilizamos objetos de tipo mock

            var mockContexto = new Mock<ContextoLibreria>();

            //2. emular al mapping
            var mockMapper = new Mock<IMapper>();

            //3. Instanciar a la clase manejador y pasarle como parametros los mocks
            Consulta.Manejador manejador= new Consulta.Manejador(mockContexto.Object, mockMapper.Object);


        }
    }
}
