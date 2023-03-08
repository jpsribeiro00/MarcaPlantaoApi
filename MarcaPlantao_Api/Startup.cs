using MarcaPlantao.Infra.IoC;
using MarcaPlantao_Api.Configuracao;
using MarcaPlantao_Servico.Identidade;
using MediatR;
using System.Text.Json.Serialization;

namespace MarcaPlantao_Api
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddMediatR(typeof(Startup));
            services.AddAutoMapperSetup();
            services.AddSwaggerSetup();
            services.AddJwtConfiguration(Configuration);
            services.AddCors();

            RegistrarServicos(services);

            services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(options =>
             options
             .AllowAnyOrigin()
             .AllowAnyMethod()
             .AllowAnyHeader()
             );

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(delegate (IEndpointRouteBuilder endpoints)
            {
                endpoints.MapControllers();
            });

            app.UseSwaggerSetup();

        }

        private static void RegistrarServicos(IServiceCollection servicos)
        {
            InjecaoDependenciaAutenticacao.RegistrarServicos(servicos);
        }
    }
}
