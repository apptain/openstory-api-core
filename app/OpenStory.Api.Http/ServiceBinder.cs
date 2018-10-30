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


            services.AddTransient<IDataService<Story>, MongoHttpRepoService<Story>>((ctx) =>
            {
                var logger = ctx.GetRequiredService<ILogger<MongoHttpRepoService<Story>>>();
                var hystrixCommandFactory = ctx.GetRequiredService<IHystrixCommandFactory>();

                //try
                //{
                //    services.Configure<MongoHttpRepoServiceConfig>(myOptions =>
                //    {
                //        myOptions.ConnectionString = "mongodb://openstory:N85R0UC45f3wGfDcAq0q@cluster0-shard-00-00-awcd9.mongodb.net:27017,cluster0-shard-00-01-awcd9.mongodb.net:27017,cluster0-shard-00-02-awcd9.mongodb.net:27017/dev?ssl=true&replicaSet=Cluster0-shard-0&authSource=admin";
                //        myOptions.DatabaseName = "openstory";

                //    });


                //    //configuration.GetSection("MongoDb").Bind(options));
                //}
                //catch (Exception ex)
                //{
                //    throw ex;
                //}

                var config = new MongoHttpRepoServiceConfig()
                {

                };

                //ctx.GetRequiredService<MongoHttpRepoServiceConfig>();


                return new MongoHttpRepoService<Story>(config, hystrixCommandFactory, logger);
            });


            return services;
        }

    }
}
