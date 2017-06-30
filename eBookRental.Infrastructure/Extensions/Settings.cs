using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace eBookRental.Infrastructure.Extensions
{
    public static class Settings
    {
        public static T GetSettings<T>(this IConfiguration configuration) where T : new()
        {
            var type = typeof(T).Name.Replace("Settings", string.Empty);
            var configurationValue = new T();
            configuration.GetSection(type).Bind(configurationValue);

            return configurationValue;
        }
    }
}
