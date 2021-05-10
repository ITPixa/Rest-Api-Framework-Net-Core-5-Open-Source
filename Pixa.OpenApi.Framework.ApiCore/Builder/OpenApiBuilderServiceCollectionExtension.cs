using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Pixa.OpenApi.Framework.ApiCore.Filters;
using Pixa.OpenApi.Framework.Core.Logging;
using System;

namespace Pixa.OpenApi.Framework.ApiCore.Builder
{
    public static class OpenApiBuilderServiceCollectionExtension
    {

        public static IOpenApiBuilder AddOpenApi(this IServiceCollection services)
        {
            var builder = new OpenApiBuilder(services);
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }
            ConfigureDefaultServices(services);
            AddOpenApiServices(services);
            return builder;
        }
        internal static IOpenApiBuilder AddOpenApiLogger(this IServiceCollection services)
        {
            var builder = new OpenApiBuilder(services);
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }
            services.TryAddEnumerable(
              ServiceDescriptor.Singleton<IOpenApiLogger, OpenApiLogger>());
            return builder;
        }
        private static void AddOpenApiServices(IServiceCollection services)
        {
            //services.TryAddEnumerable(
            //ServiceDescriptor.Transient<IApplicationModelProvider, DefaultApplicationModelProvider>());
        }
        private static void ConfigureDefaultServices(IServiceCollection services)
        {
            services.AddControllers(options =>
                 {
                     options.Filters.Add<ModelValidationFilter>();
                     options.EnableEndpointRouting = false;
                 }
            );
            services.AddOpenApiLogger();
            services.AddRouting();
        }
    }
}

