namespace Pixa.OpenApi.Framework.ApiCore.Builder
{
    public static class OpenApiBuilderExtension
    {
        public static IOpenApiBuilder AddOpenApiLogger(this IOpenApiBuilder openApiBuilder)
        {
            return openApiBuilder.Services.AddOpenApi();
        }
    }
}
