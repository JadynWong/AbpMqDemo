using System;
using System.Threading.Tasks;

using MqEvent;

using Volo.Abp.DependencyInjection;
using Volo.Abp.EventBus.Distributed;

namespace Consumer
{
    /// <summary>
    /// Used to listen messages sent to App2 by App1.
    /// </summary>
    public class ConsumerTextEventHandler : IDistributedEventHandler<TestMessagesEventData>, ITransientDependency
    {
        private readonly IDistributedEventBus _distributedEventBus;

        public ConsumerTextEventHandler(IDistributedEventBus distributedEventBus)
        {
            _distributedEventBus = distributedEventBus;
        }

        public Task HandleEventAsync(TestMessagesEventData eventData)
        {
            Console.WriteLine("************************ INCOMING MESSAGE ****************************");
            Console.WriteLine(eventData.Text);
            Console.WriteLine("**********************************************************************");
            Console.WriteLine();

            return Task.CompletedTask;
        }
    }
}
