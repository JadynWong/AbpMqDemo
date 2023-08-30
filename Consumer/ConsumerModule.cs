using System;
using System.Collections.Generic;
using System.Text;

using Volo.Abp.Autofac;
using Volo.Abp.EventBus.RabbitMq;
using Volo.Abp.Modularity;
using Volo.Abp.RabbitMQ;

namespace Consumer
{
    [DependsOn(
        typeof(AbpAutofacModule),
        typeof(AbpEventBusRabbitMqModule))]
    public class ConsumerModule : AbpModule
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
                options.ClientName = "Consumer";//Important! Must be different from the publisher's ClientName
                options.ExchangeName = "TestMessages";
            });
        }
    }
}
