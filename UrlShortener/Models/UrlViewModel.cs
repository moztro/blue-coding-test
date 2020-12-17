using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UrlShortener.Models
{
    public class UrlViewModel
    {
        public int Id { get; set; }

        [Required]
        [Url(ErrorMessage = "Please type a valid URL")]
        public string OriginalUrl { get; set; }

        public string ShortenUrl { get; set; }
    }
}
