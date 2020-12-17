using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UrlShortener.Domain;
using UrlShortener.Models;
using UrlShortener.Services;
using UrlShortener.Storage;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UrlShortener.Controllers
{
    public class UrlController : Controller
    {
        private IShortenerService _shortenerService;

        public UrlController(
            IShortenerService shortenerService
        )
        {
            _shortenerService = shortenerService;
        }

        // GET: api/<UrlController>
        [HttpGet]
        public IActionResult Create()
        {
            return View("Create", new UrlViewModel());
        }

        [HttpPost]
        public IActionResult CreateURL(UrlViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(model);

            //string shortenUrl = _shortenerService.Shorten(model.OriginalUrl);

            var url = new Url();
            url.OriginalUrl = model.OriginalUrl;
            url.Active = true;

            var inserted = MockStorage.Add(url);

            var result = new UrlViewModel 
            { 
                Id = inserted.Id, 
                ShortenUrl = $"{HttpContext.Request.Path}/{inserted.Id}" 
            };

            return View("Success", result);
        }

        [HttpGet]
        public IActionResult Redirect(int id)
        {
            Url url = MockStorage.GetById(id);

            if (url == null)
                return BadRequest("No record found with the specified key");

            return Redirect(url.OriginalUrl);
        }
    }
}
