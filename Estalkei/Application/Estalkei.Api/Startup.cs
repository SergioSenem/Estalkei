using AutoMapper;
using Core.Data.Contexts;
using Estalkei.Data.Contexts;
using Estalkei.Data.Repositories;
using Estalkei.Domain.Interfaces;
using Estalkei.Services.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace Estalkei.Api
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

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddScoped<IProviderService, ProviderService>();
            services.AddScoped<IExchangeTypeService, ExchangeTypeService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IExchangeService, ExchangeService>();
            services.AddScoped<IExchangeProductService, ExchangeProductService>();

            services.AddScoped<IProviderRepository, ProviderRepository>();
            services.AddScoped<IExchangeTypeRepository, ExchangeTypeRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IExchangeRepository, ExchangeRepository>();
            services.AddScoped<IExchangeProductRepository, ExchangeProductRepository>();

            services.AddSingleton<IContext, EstalkeiContext>();

            services.AddDbContext<EstalkeiContext>(options =>
            {
                options.UseMySql(Configuration.GetConnectionString(nameof(EstalkeiContext)),
                    assembly => assembly.MigrationsAssembly(typeof(EstalkeiContext).Assembly.FullName));
            });
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

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
