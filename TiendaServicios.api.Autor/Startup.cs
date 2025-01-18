using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TiendaServicios.api.Autor.Aplicacion;
using TiendaServicios.api.Autor.Persistencia;
using AutoMapper;

namespace TiendaServicios.api.Autor
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
            //3. fluent validation
            services.AddControllers().AddFluentValidation(options => options.RegisterValidatorsFromAssemblyContaining<Nuevo>());

            //1. cnfigurar la cadena de conexion y el dbcontext
            services.AddDbContext<ContextoAutor>(options =>
            {
                options.UseNpgsql(Configuration.GetConnectionString("defaultConnection"));
            });

            //2. llamar al servicio mediaTR
            services.AddMediatR(typeof(Nuevo.Manejador).Assembly);

            //4. configurar automapper

            services.AddAutoMapper(typeof(MappingProfile).Assembly);





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
