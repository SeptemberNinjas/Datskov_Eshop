using Eshop.Core;

namespace Eshop.Menu.Commands
{
    internal class ShowOrdersCommand(ApplicationContext context, IRepository<Order> orderManager) : IMenuCommand
    {
        public string Description { get; } = "Show my orders";

        public void Execute() => ExecuteAsync().Wait();

        public async Task ExecuteAsync()
        {
            var previosPage = context.CurrentPage;
            context.CurrentPage = new OrdersPage(previosPage, []) { Orders = [.. await orderManager.GetAllAsync()] };
        }
    }
}
