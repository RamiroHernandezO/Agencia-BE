using Application.Interface;
using Application.Main;
using AutoMapper;
using Data.Agencia;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Pattern.Repository;
using Pattern.UnitOfWork;
using AgenciaAutomoviles.Controllers;
using Transversal.Common;
using Transversal.Logging;
using Transversal.Mapper;

namespace AgenciaBE
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {

            services.AddSingleton(Configuration);
            services.AddAutoMapper(a => a.AddProfile(new MappingProfile()));

            var connectionString = Configuration.GetConnectionString("AgenciaAutomovil");
            services.AddDbContext<AgenciaContext>(options =>
            options.UseSqlServer(connectionString), ServiceLifetime.Transient);


            services.AddCors(options =>
            {
                options.AddPolicy("All", builder =>
                {
                    builder.AllowAnyHeader()
                    .AllowAnyMethod()
                    .SetIsOriginAllowed((Host) => true)
                    .AllowCredentials();
                });
            });

            services.AddAutoMapper(typeof(Startup));
            services.AddScoped(typeof(IRepositoryWrite<,>), typeof(Repository<,>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));
            services.AddScoped<RolesApplication>();
            services.AddScoped<EntregaApplication>();
            services.AddScoped<RefaccionApplication>();
            services.AddScoped<ServicioRefaccionApplication>();
            services.AddScoped<ServicioApplication>();
            services.AddScoped<VehiculosApplication>();
            services.AddScoped<UsuarioApplication>();
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Agencia Automovilistica", Version = "v1" });
            });
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "AgenciaBack v1"));


            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors("All");
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}