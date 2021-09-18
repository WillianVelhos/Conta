using Conta.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using MediatR;
using Conta.Application.Inclusao;
using Conta.Domain.Services;
using Conta.Domain.Repositories;
using Mapster;
using domainModels = Conta.Domain.Models;
using Conta.Application.Listagem;

namespace Conta.WebApi
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
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Conta.WebApi", Version = "v1" });
            });

            services.AddDbContext<ContaContext>(options => 
               options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddMediatR(typeof(Startup));

            services.AddScoped<IRequestHandler<InclusaoCommand, InclusaoCommandResult>, InclusaoCommandHandler>();

            services.AddScoped<ContaDomainService>();

            services.AddScoped<IContaRepository, ContaRepository>();
            services.AddScoped<IContaService, ContaService>();

            TypeAdapterConfig<InclusaoCommand, domainModels.Conta>.NewConfig()
                    .ConstructUsing(c => new domainModels.Conta(c.Nome, c.ValorOriginal, c.DataVencimento, c.DataPagamento));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Conta.WebApi v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
