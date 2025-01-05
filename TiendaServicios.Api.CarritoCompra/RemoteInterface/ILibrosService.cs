using System;
using System.Threading.Tasks;
using TiendaServicios.Api.CarritoCompra.Modelo.RemoteModel;

namespace TiendaServicios.Api.CarritoCompra.RemoteInterface
{
    public interface ILibrosService
    {
        public Task<(bool resultado,LibroRemoto libro,string ErrorMenssage)> GetLibro(Guid libroId);
    }
}
