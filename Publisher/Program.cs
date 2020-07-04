using System;

using Microsoft.Extensions.DependencyInjection;

using OnlyPublisher;

using Volo.Abp;
using System.Threading.Tasks;

namespace Publisher
{
    class Program
    {
        static async Task Main(string[] args)
        {
            using (var application = AbpApplicationFactory.Create<PublisherModule>(options =>
            {
                options.UseAutofac();
            }))
            {
                application.Initialize();

                var messagingService = application
                    .ServiceProvider
                    .GetRequiredService<MessagingService>();

                await messagingService.RunAsync();

                application.Shutdown();
            }
        }
    }
}
