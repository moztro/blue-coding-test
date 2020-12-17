using System;
using System.Collections.Generic;
using System.Linq;
using UrlShortener.Domain;

namespace UrlShortener.Storage
{
    public static class MockStorage
    {
        private static List<Url> Urls = new List<Url> { };

        public static Url Add(Url url)
        {
            if (url == null)
                throw new ArgumentNullException(nameof(url));

            url.Id = GetSequentialID();
            Urls.Add(url);

            return url;
        }

        public static Url GetById(int id)
        {
            return Urls.FirstOrDefault(url => url.Id == id);
        }

        private static int GetSequentialID()
        {
            return Urls.Count + 1;
        }
    }
}
