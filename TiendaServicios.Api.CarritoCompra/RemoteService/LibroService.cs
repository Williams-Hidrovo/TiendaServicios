using Microsoft.Extensions.Logging;
using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using TiendaServicios.Api.CarritoCompra.Modelo.RemoteModel;
using TiendaServicios.Api.CarritoCompra.RemoteInterface;

namespace TiendaServicios.Api.CarritoCompra.RemoteService
{
    public class LibroService : ILibrosService
    {
        private readonly IHttpClientFactory _httpClient;
        private readonly ILogger<ILibrosService> _logger;

        public LibroService(IHttpClientFactory httpClient, ILogger<ILibrosService> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        public async Task<(bool resultado, LibroRemoto libro, string ErrorMenssage)> GetLibro(Guid libroId)
        {
            try
            {
                var cliente = _httpClient.CreateClient("Libros");

                //devuelve la response de la api
                var response =await cliente.GetAsync($"api/LibroMaterial/{libroId}");

                if (response.IsSuccessStatusCode)
                {
                    var contenido = await response.Content.ReadAsStringAsync();
                    var options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
                    var resultado = JsonSerializer.Deserialize<LibroRemoto>(contenido,options);
                    return (true,resultado,"");
                }

                return (false, null, response.ReasonPhrase);
            }
            catch(Exception e)
            {
                _logger?.LogError(e.ToString());
                return (false, null, e.Message);
            }
        }
    }
}
