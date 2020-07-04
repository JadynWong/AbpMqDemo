using System;
using System.Threading.Tasks;

using MqEvent;

using Volo.Abp.DependencyInjection;
using Volo.Abp.EventBus.Distributed;

namespace Consumer
{
    /// <summary>
    /// Used to know when App2 has received a message sent by App1.
    /// </summary>
    public class ConsumerTextReceivedEventHandler : IDistributedEventHandler<TestMessagesEventData>, ITransientDependency
    {
        public Task HandleEventAsync(TestMessagesEventData eventData)
        {
            Console.WriteLine("--------> Consumer has received the message: " + eventData.Text);
            Console.WriteLine();

            return Task.CompletedTask;
        }
    }
}
