
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;

namespace Bookstore.Data
{
    public sealed class BookstoreConfiguration
    {
        private static readonly Lazy<BookstoreConfiguration> Lazy = new Lazy<BookstoreConfiguration>(() => new BookstoreConfiguration());

        private static BookstoreConfiguration Instance => Lazy.Value;

        private readonly Dictionary<string, string> _appSettings = new Dictionary<string, string>();

        private BookstoreConfiguration()
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables()
                .Build();

            foreach (var kvp in configuration.AsEnumerable())
            {
                _appSettings[kvp.Key] = kvp.Value;
            }
        }

        public static void Add(string key, string value)
        {
            Instance._appSettings[key] = value;
        }

        public static string Get(string key)
        {
            return Instance._appSettings.TryGetValue(key, out var value) ? value : null;
        }

        public static T Get<T>(string key)
        {
            var value = Get(key);
            return (T)Convert.ChangeType(value, typeof(T));
        }
    }
}
