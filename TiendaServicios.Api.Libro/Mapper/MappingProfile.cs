using AutoMapper;
using TiendaServicios.Api.Libro.Modelo;
using TiendaServicios.Api.Libro.Modelo.Dtos;

namespace TiendaServicios.Api.Libro.Mapper
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<LibreriaMaterial, LibroMaterialDto>().ReverseMap();
        }
    }
}
