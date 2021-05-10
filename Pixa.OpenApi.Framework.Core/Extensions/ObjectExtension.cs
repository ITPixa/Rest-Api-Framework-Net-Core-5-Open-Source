using System.Text.Json;

namespace Pixa.OpenApi.Framework.Core.Extensions
{
    public static class ObjectExtension
    {
        public static string JsonSerialize<T>(this T obj)
        {
            if (obj is null)
                return string.Empty;
            return JsonSerializer.Serialize(obj);
        }
    }
}
