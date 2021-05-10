using Microsoft.Extensions.DependencyInjection;
using System;

namespace Pixa.OpenApi.Framework.ApiCore.Builder
{
    public class OpenApiBuilder : IOpenApiBuilder
    {
        /// <summary>
        /// Initializes a new <see cref="OpenApiBuilder"/> instance.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection" /> to add services to.</param>
        public OpenApiBuilder(IServiceCollection services)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }
            Services = services;
        }

        /// <inheritdoc />
        public IServiceCollection Services { get; }
    }
    
}