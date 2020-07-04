
using MqEvent;

using System;
using System.Threading.Tasks;

using Volo.Abp.DependencyInjection;
using Volo.Abp.EventBus.Distributed;

namespace OnlyPublisher
{
    public class MessagingService : ITransientDependency
    {
        private readonly IDistributedEventBus _distributedEventBus;

        public MessagingService(IDistributedEventBus distributedEventBus)
        {
            _distributedEventBus = distributedEventBus;
        }

        public async Task RunAsync()
        {
            Console.WriteLine("*** Started the Publisher ***");
            Console.WriteLine("Write a message and press ENTER to send to the Consumer.");
            Console.WriteLine("Press ENTER (without writing a message) to stop the application.");

            string message;
            do
            {
                Console.WriteLine();

                message = Console.ReadLine();

                if (!message.IsNullOrEmpty())
                {
                    await _distributedEventBus.PublishAsync(new TestMessagesEventData(message));
                }
                else
                {
                    await _distributedEventBus.PublishAsync(new TestMessagesEventData("App1 is exiting. Bye bye...!"));
                }

            } while (!message.IsNullOrEmpty());
        }
    }
}