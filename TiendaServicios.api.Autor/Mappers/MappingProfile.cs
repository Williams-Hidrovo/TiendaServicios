using AutoMapper;
using TiendaServicios.api.Autor.Aplicacion.Dtos;
using TiendaServicios.api.Autor.Modelo;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<AutorLibro, AutorDto>().ReverseMap();
    }
}