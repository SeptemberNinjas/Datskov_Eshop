using Microsoft.Extensions.Configuration;

namespace Eshop
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var appconfig = new ConfigurationBuilder()
                    .AddJsonFile("config.json", optional: false)
                    .Build();

            var context = new ApplicationContext(appconfig);

            while (true)
            {
                var command = context.CurrentPage.Show();
                await command.ExecuteAsync();
            }
        }
    }
}
