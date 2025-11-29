using Microsoft.Extensions.DependencyInjection;
using SharedAPI.Helpers;
using SharedAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedAPI.Configurations
{
    public static class ConfigureServices
    {
        #region Methods

        public static IServiceCollection SharedAPIServiceCollection(this IServiceCollection services)
        {
            services.AddScoped<IRedisCacheProvider, RedisCacheProvider>();
            services.AddScoped<ICacheInvalidator, CacheInvalidator>();

            return services;
        }

        #endregion
    }
}
