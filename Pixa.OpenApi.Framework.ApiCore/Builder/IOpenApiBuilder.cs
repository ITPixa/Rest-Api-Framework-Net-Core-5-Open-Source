using Microsoft.Extensions.DependencyInjection;

namespace Pixa.OpenApi.Framework.ApiCore.Builder
{
    /// <summary>
    /// An interface for configuring MVC services.
    /// </summary>
    public interface IOpenApiBuilder
    {
        /// <summary>
        /// Gets the <see cref="IServiceCollection"/> where MVC services are configured.
        /// </summary>
        IServiceCollection Services { get; }

    }
}
