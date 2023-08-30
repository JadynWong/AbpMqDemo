using System;
using System.Collections.Generic;
using System.Text;

using Volo.Abp.Autofac;
using Volo.Abp.EventBus.RabbitMq;
using Volo.Abp.Modularity;
using Volo.Abp.RabbitMQ;

namespace Publisher
{
    [DependsOn(
        typeof(AbpAutofacModule),
        typeof(AbpEventBusRabbitMqModule))]
    public class PublisherModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            PostConfigure<AbpRabbitMqOptions>(options =>
            {
                options.Connections.Default.HostName = "localhost";
                options.Connections.Default.UserName = "admin";
                options.Connections.Default.Password = "admin";
            });
            Configure<AbpRabbitMqEventBusOptions>(options =>
            {
                options.ClientName = "OnlyPublisher";//Important! Must be different from the consumer's ClientName
                options.ExchangeName = "TestMessages";
            });
        }
    }
}
