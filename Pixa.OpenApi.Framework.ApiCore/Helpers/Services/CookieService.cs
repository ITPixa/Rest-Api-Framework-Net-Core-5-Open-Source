using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Pixa.OpenApi.Framework.ApiCore.Helpers.Services
{
    public class CookieService : ICookieService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public CookieService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public void Delete(string key)
        {
            _httpContextAccessor.HttpContext.Response.Cookies.Delete(key);
        }

        public string Read(string key)
        {
            return _httpContextAccessor?.HttpContext?.Request?.Cookies[key];
        }

        public T Read<T>(string key)
        {
            T result = default;
            string cookieValue = _httpContextAccessor?.HttpContext?.Request?.Cookies[key];
            if (!string.IsNullOrEmpty(cookieValue))
                result = JsonSerializer.Deserialize<T>(cookieValue);
            return result;
        }

        public IDictionary<string, string> ReadAll()
        {
            IDictionary<string, string> _cookies = new Dictionary<string, string>();
            if (_httpContextAccessor.HttpContext != null && _httpContextAccessor.HttpContext.Request != null
                            && _httpContextAccessor.HttpContext.Request.Cookies != null)
            {
                foreach (var key in _httpContextAccessor.HttpContext.Request.Cookies.Keys)
                {
                    _cookies.Add(new KeyValuePair<string, string>(key, Read(key)));
                }
            }
            return _cookies;
        }

        public void Write(string key, string value, string domain, int expiryDays, bool isSecure)
        {
            var cookieOptions = new CookieOptions
            {
                Secure = isSecure,
                SameSite = SameSiteMode.None
            };
            if (expiryDays > 0) cookieOptions.Expires = DateTime.Now.AddDays(expiryDays);
            if (!string.IsNullOrEmpty(domain)) cookieOptions.Domain = "." + domain;
            _httpContextAccessor.HttpContext.Response.Cookies.Append(key, value, cookieOptions);
        }
    }
}
