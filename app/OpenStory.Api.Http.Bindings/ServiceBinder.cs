//using System;
//using Microsoft.Extensions.Configuration;
//using Microsoft.Extensions.DependencyInjection;
//using Microsoft.Extensions.Logging;
//using Microsoft.Extensions.Options;

//namespace OpenStory.Api.Htt
//{
//    public static class ServiceBinder
//    {
//        public static IServiceCollection BindDomainServices(this IServiceCollection services, IConfigurationRoot configuration)
//        {
//            if (services == null)
//            {
//                throw new ArgumentNullException(nameof(services));
//            }

//            //TODO add config checks
//            //if (configuration == null)
//            //{
//            //    throw new ArgumentNullException(nameof(configuration));
//            //}

//            services.Configure<MongoHttpRepoConfig>(configuration.GetSection("DrupalService"));

//            services.Add(ServiceDescriptor.Transient<IArticleHttpService>(provider =>
//            {
//                var logger = provider.GetRequiredService<ILogger<ArticleHttpServiceImplementation>>();
//                var options = provider.GetRequiredService<IOptions<ArticleHttpServiceOptions>>();

//                return new ArticleHttpServiceImplementation(logger, options);
//            }));

            

//            return services;
//        }

//    }
//}
