using Microsoft.AspNetCore.Mvc;
using System;
using UrlShortener.Controllers;
using UrlShortener.Domain;
using UrlShortener.Storage;
using Xunit;

namespace UrlShortener.Tests
{
    public class UrlShortenerUnitTests
    {
        [Fact]
        public void CanIAddtoStorage()
        {
            var url = new Url();
            url.OriginalUrl = "http://cool.xyz";
            url.Active = true;

            var inserted = MockStorage.Add(url);

            Assert.NotNull(inserted);
            Assert.Equal(url.OriginalUrl, inserted.OriginalUrl);
        }

        [Fact]
        public void CannotAddToStorage()
        {
            Url url = null;

            Assert.Throws<ArgumentNullException>(() => MockStorage.Add(url));
        }

        [Fact]
        public void CanGetFromStorage()
        {
            var url = new Url();
            url.OriginalUrl = "long  URL";
            url.Active = true;

            var inserted = MockStorage.Add(url);

            Assert.NotNull(inserted);
            Assert.Equal(url.OriginalUrl, inserted.OriginalUrl);

            var retrieved = MockStorage.GetById(inserted.Id);

            Assert.NotNull(retrieved);
            Assert.Equal(inserted.Id, retrieved.Id);
        }

        [Fact]
        public void CannotGetFromStorage()
        {
            var url = new Url();
            url.OriginalUrl = "long  URL";
            url.Active = true;

            var inserted = MockStorage.Add(url);

            Assert.NotNull(inserted);
            Assert.Equal(url.OriginalUrl, inserted.OriginalUrl);

            var retrieved = MockStorage.GetById(999);

            Assert.Null(retrieved);
        }

        [Fact]
        public void CanRedirect()
        {
            var controller = new UrlController(null);

            CanIAddtoStorage();

            var result = controller.Redirect(1);

            Assert.NotNull(result);
            Assert.Equal("http://cool.xyz", ((RedirectResult)result).Url);
        }
    }
}
