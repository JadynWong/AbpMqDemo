using System;
using System.Threading.Tasks;

using Volo.Abp;

namespace Consumer
{
    static class Program
    {
        static void Main(string[] args)
        {
            using (var application = AbpApplicationFactory.Create<ConsumerModule>(options =>
            {
                options.UseAutofac();
            }))
            {
                application.Initialize();

                Console.WriteLine("Pass any key to exit.");
                Console.ReadKey();

                application.Shutdown();
            }
        }

    }
}
