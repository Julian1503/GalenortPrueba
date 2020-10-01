using Galenort.Aplicacion;
using Galenort.Aplicacion.Comprobante;
using Galenort.Aplicacion.Comprobante.Comprobante;
using Galenort.Aplicacion.DetalleComprobante;
using Galenort.Aplicacion.DetalleCtaCte;
using Galenort.Aplicacion.EstadoComprobante;
using Galenort.Aplicacion.Paciente;
using Galenort.Aplicacion.Parentezco;
using Galenort.Aplicacion.Persona;
using Galenort.Aplicacion.TipoComprobante;
using Galenort.Dominio;
using Galenort.Dominio.Entidades;
using Galenort.Dominio.Repositorio;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace WebServiceGalenort
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        readonly string MyAllowSpecificOrigins = "_policy";
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                    builder =>
                    {
                        builder.WithOrigins(@"https://localhost:44325/").AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
                    });
            });

            services.AddControllers().AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );
            IoC(services);

        }

        private static void IoC(IServiceCollection services)
        {
            services.AddDbContext<GestionSanatorialContext>();
            services.AddTransient<IPersonaServicio, PersonaServicio>();
            services.AddTransient<IRepositorio<Persona>, Repositorio<Persona>>();
            services.AddTransient<IComprobanteServicio, ComprobanteServicio>();
            services.AddTransient<IRepositorio<Comprobante>, Repositorio<Comprobante>>();
            services.AddTransient<IDetalleComprobanteServicio, DetalleComprobanteServicio>();
            services.AddTransient<IRepositorio<DetalleComprobante>, Repositorio<DetalleComprobante>>();
            services.AddTransient<IDetalleCtaCteServicio, DetalleCtaCteServicio>();
            services.AddTransient<IRepositorio<DetalleCtaCte>, Repositorio<DetalleCtaCte>>();
            services.AddTransient<IPacienteServicio, PacienteServicio>();
            services.AddTransient<IRepositorio<Paciente>, Repositorio<Paciente>>();
            services.AddTransient<IParentezcoServicio, ParentezcoServicio>();
            services.AddTransient<IRepositorio<Parentezco>, Repositorio<Parentezco>>();
            services.AddTransient<ITipoComprobanteServicio, TipoComprobanteServicio>();
            services.AddTransient<IRepositorio<TipoComprobante>, Repositorio<TipoComprobante>>();
            services.AddTransient<IEstadoComprobanteServicio, EstadoComprobanteServicio>();
            services.AddTransient<IRepositorio<EstadoComprobante>, Repositorio<EstadoComprobante>>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(MyAllowSpecificOrigins);

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
