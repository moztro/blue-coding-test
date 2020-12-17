using System;

namespace UrlShortener.Services
{
    public interface IShortenerService
    {
        /// <summary>
        /// Receives an original URL and return a shorten one
        /// </summary>
        /// <param name="originalUrl"></param>
        /// <returns></returns>
        string Shorten(string originalUrl);
    }
}
