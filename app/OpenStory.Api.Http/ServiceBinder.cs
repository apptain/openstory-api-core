using System;
using Hystrix.Dotnet;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using OpenStory.Api.Data.Http.Mongo;
using OpenStory.Api.Http.Domain;
using OpenStory.Data;

namespace OpenStory.Api.Http
{
    public static class ServiceBinder
    {
        public static IServiceCollection BindDomainServices(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            try
            {
                services.Configure<IMongoHttpRepoServiceConfig>(options => configuration.GetSection("MongoDb").Bind(options));
            }
            catch(Exception ex)
            {
                throw ex;
            }
            services.AddSingleton<IDataService<Story>, MongoHttpRepoService<Story>>((ctx) =>
            {
                var logger = ctx.GetRequiredService<ILogger<MongoHttpRepoService<Story>>>();
                var hystrixCommandFactory = ctx.GetRequiredService<IHystrixCommandFactory>();

                var config = ctx.GetRequiredService<IMongoHttpRepoServiceConfig>();


                return new MongoHttpRepoService<Story>(config, hystrixCommandFactory, logger);
            });


            return services;
        }

    }
}
