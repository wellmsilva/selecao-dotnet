using Indra.SelecaoDotNet.Application.Interfaces;
using Indra.SelecaoDotNet.Application.Services;
using Indra.SelecaoDotNet.Dominio.Interfaces.Repositories;
using Indra.SelecaoDotNet.Dominio.Interfaces.Services;
using Indra.SelecaoDotNet.Dominio.Services;
using Indra.SelecaoDotNet.Infra.Data.Contexts;
using Indra.SelecaoDotNet.Infra.Data.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Indra.SelecaoDotNet.IoC
{
    public class InjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services, string connection)
        {
            services.AddDbContext<BaseContext>(options =>
               options.UseSqlite(connection)
           );

            AlunoRegisterServices(services);
            CartaoRegisterServices(services);
            CursoRegisterServices(services);
            MatriculaRegisterServices(services);
        }

        private static void MatriculaRegisterServices(IServiceCollection services)
        {
            services.AddScoped<IMatriculaRepository, MatriculaRepository>();
        }

        private static void CursoRegisterServices(IServiceCollection services)
        {
            services.AddScoped<ICursoAppService, CursoAppService>();
            services.AddScoped<ICursoService, CursoService>();
            services.AddScoped<ICursoRepository, CursoRepository>();
        }

        private static void CartaoRegisterServices(IServiceCollection services)
        {
            services.AddScoped<ICartaoRepository, CartaoRepository>();
        }

        private static void AlunoRegisterServices(IServiceCollection services)
        {
            services.AddScoped<IUsuarioAppService, UsuarioAppService>();
            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
        }

        public static void UpdateDatabase(IApplicationBuilder app)
        {

            using (var serviceScope = app.ApplicationServices
              .GetRequiredService<IServiceScopeFactory>()
              .CreateScope())
            {
                using (var context = serviceScope.ServiceProvider.GetService<BaseContext>())
                {
                    context.Database.Migrate();
                }
            }

        }

    }
}
