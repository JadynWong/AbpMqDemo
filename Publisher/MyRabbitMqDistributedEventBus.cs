using System;
using System.Collections.Generic;
using System.Text;

using Volo.Abp.DependencyInjection;
using Volo.Abp.EventBus.Distributed;
using Volo.Abp.EventBus.RabbitMq;
using Microsoft.Extensions.Options;
using Volo.Abp.RabbitMQ;
using Microsoft.Extensions.DependencyInjection;

namespace Publisher
{
    [Dependency(ReplaceServices = true)]
    [ExposeServices(typeof(IDistributedEventBus), typeof(RabbitMqDistributedEventBus))]
    public class MyRabbitMqDistributedEventBus : RabbitMqDistributedEventBus
    {
        public MyRabbitMqDistributedEventBus(
            IOptions<AbpRabbitMqEventBusOptions> options,
            IConnectionPool connectionPool,
            IRabbitMqSerializer serializer,
            IServiceScopeFactory serviceScopeFactory,
            IOptions<AbpDistributedEventBusOptions> distributedEventBusOptions,
            IRabbitMqMessageConsumerFactory messageConsumerFactory) :
            base(options, connectionPool, serializer, serviceScopeFactory, distributedEventBusOptions, messageConsumerFactory)
        {
        }

        new public void Initialize()
        {
            //Consumer = MessageConsumerFactory.Create(
            //    new ExchangeDeclareConfiguration(
            //        AbpRabbitMqEventBusOptions.ExchangeName,
            //        type: "direct",
            //        durable: true
            //    ),
            //    new QueueDeclareConfiguration(
            //        AbpRabbitMqEventBusOptions.ClientName,
            //        durable: true,
            //        exclusive: false,
            //        autoDelete: false
            //    ),
            //    AbpRabbitMqEventBusOptions.ConnectionName
            //);

            //Consumer.OnMessageReceived(ProcessEventAsync);

            //SubscribeHandlers(AbpDistributedEventBusOptions.Handlers);
        }
    }
}
