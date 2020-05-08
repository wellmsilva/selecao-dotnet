using Indra.SelecaoDotNet.Application.AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System;

using AutoMapper;

namespace Indra.SelecaoDotNet.WebApi.Extensions
{
    public static class AutoMapperExtension
    {
        public static void AddAutoMapperSetup(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            var config = AutoMapperConfig.RegisterMappings();
            IMapper mapper = config.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
