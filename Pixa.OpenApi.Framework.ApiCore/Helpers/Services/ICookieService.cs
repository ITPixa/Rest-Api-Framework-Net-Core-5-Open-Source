using System.Collections.Generic;

namespace Pixa.OpenApi.Framework.ApiCore.Helpers.Services
{
    public interface ICookieService
    {
        /// <summary>
        /// Add a new cookie and value 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="domain"></param>
        /// <param name="expiryDays"></param>
        /// <param name="isSecure"></param>
        void Write(string key, string value, string domain, int expiryDays, bool isSecure);

        /// <summary>
        /// Get value of cookie
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        T Read<T>(string key);

        /// <summary>
        /// Get value of cookie
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        string Read(string key);


        /// <summary>
        /// Get list of all cookie
        /// </summary>
        /// <returns></returns>
        IEnumerable<KeyValuePair<string, string>> ReadAll();

        /// <summary>
        /// Set an expired cookie
        /// </summary>
        /// <param name="key"></param>
        void Delete(string key);
    }
}
