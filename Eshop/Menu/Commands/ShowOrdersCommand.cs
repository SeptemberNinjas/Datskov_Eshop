using Eshop.Core;

namespace Eshop.Menu.Commands
{
    internal class ShowOrdersCommand(ApplicationContext context, IRepository<Order> orderManager) : IMenuCommand
    {
        public string Description { get; } = "Show my orders";

        public void Execute() => ExecuteAsync().Wait();

        public async Task ExecuteAsync()
        {
            context.CurrentPage = new OrdersPage([]) { Orders = [.. await orderManager.GetAllAsync()] };
        }
    }
}
