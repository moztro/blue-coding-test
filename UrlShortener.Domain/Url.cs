using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace UrlShortener.Domain
{
    [Table("Urls")]
    public class Url
    {
        public int Id { get; set; }

        /// <summary>
        /// The original input URL to be shortened
        /// </summary>
        public string OriginalUrl { get; set; }

        /// <summary>
        /// The key mapped to the original URL
        /// </summary>
        public string Key { get; set; }

        public DateTime? ExpirationDate { get; set; }

        /// <summary>
        /// Get the last time that the URL was requested for access
        /// </summary>
        public DateTime? LastTimeAccesed { get; set; }

        /// <summary>
        /// The number of times that a URL was accesed
        /// </summary>
        public int TimesAccessed { get; set; }

        public bool Active { get; set; }
    }
}
