using Autofac;
using eBookRental.Infrastructure.Extensions;
using eBookRental.Infrastructure.Settings;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace eBookRental.Infrastructure.IoC.Modules
{
    public class SettingsModule : Autofac.Module
    {
        private readonly IConfiguration _configuration;

        public SettingsModule(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterInstance(_configuration.GetSettings<PrimarySettings>())
                   .SingleInstance();
            builder.RegisterInstance(_configuration.GetSettings<AuthSettings>())
                  .SingleInstance();
            builder.RegisterInstance(_configuration.GetSettings<SqlSettings>())
                  .SingleInstance();
        }
    }
}

