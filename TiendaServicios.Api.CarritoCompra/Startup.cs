using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Reflection;
using TiendaServicios.Api.CarritoCompra.Persistencia;
using TiendaServicios.Api.CarritoCompra.RemoteInterface;
using TiendaServicios.Api.CarritoCompra.RemoteService;

namespace TiendaServicios.Api.CarritoCompra
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            //1. configurar conexion string mysql

            services.AddDbContext<CarritoContexto>(options =>
                options.UseMySql(Configuration.GetConnectionString("DefaultConnection")));

            //2. Registrar MediatR y escanear el ensamblado actual en busca de handlers
            services.AddMediatR(Assembly.GetExecutingAssembly());
            //2B configuracion alternativa
            //services.AddMediatR(typeof(CreateCarritoCompraHandler));

            //3 configurar los endpoints de los otros microservicios a los que se desea consumir
            //estos deben configurarse en el appsettings y se encuentran en properties launchsettings

            //4. agregar el HttpClient
            services.AddHttpClient("Libros", config =>
            {
                config.BaseAddress = new Uri(Configuration["Services:Libros"]);
            });

            //5 configurar la inyeccion de servicios e interfaces
            services.AddScoped<ILibrosService, LibroService>();

            


        }




        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
    }
}
