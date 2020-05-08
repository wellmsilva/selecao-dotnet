using System;
using Microsoft.Extensions.Configuration;
using Indra.SelecaoDotNet.IoC;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Indra.SelecaoDotNet.WebApi.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

namespace Indra.SelecaoDotNet.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            _appSettingsSection = Configuration.GetSection("AppSettings");
        }

        public IConfiguration Configuration { get; }

        private readonly IConfigurationSection _appSettingsSection;

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddAutoMapperSetup();
            services.AddControllers();
            services.AddCors();            
            services.AddSwaggerDocumentation();
            services.ConfigureAuthentication(_appSettingsSection);
            RegisterServices(services);
        }

        private void RegisterServices(IServiceCollection services)
        {
            var connection = string.Format(Configuration["ConnectionStrings:SqliteConnection"], AppDomain.CurrentDomain.BaseDirectory);
            InjectorBootStrapper.RegisterServices(services, connection);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            InjectorBootStrapper.UpdateDatabase(app);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(x => x
             .AllowAnyOrigin()
             .AllowAnyMethod()
             .AllowAnyHeader());

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseSwaggerDocumentation();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }


    }
}
