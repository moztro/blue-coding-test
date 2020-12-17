
namespace UrlShortener.Services
{
    public class ShortenerService : IShortenerService
    {
        /// <summary>
        /// Should return a shorten string for the original URL
        /// </summary>
        /// <param name="originalUrl"></param>
        /// <returns></returns>
        public string Shorten(string originalUrl)
        {
            return originalUrl;
        }
    }
}
