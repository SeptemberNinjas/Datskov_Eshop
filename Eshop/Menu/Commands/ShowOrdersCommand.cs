using Eshop.Application.OrderHandlers;

namespace Eshop.Menu.Commands
{
    internal class ShowOrdersCommand : IMenuCommand
    {
        private readonly ApplicationContext _context;
        private readonly GetOrderHandler _getOrderHandler;
        public string Description { get; } = "Show my orders";

        public ShowOrdersCommand(ApplicationContext context, GetOrderHandler getOrderHandler)
        {
            _context = context;
            _getOrderHandler = getOrderHandler;
        }
        public void Execute() => ExecuteAsync().Wait();

        public async Task ExecuteAsync()
        {
            var ordersGetResult = await _getOrderHandler.GetAllAsync();

            if (ordersGetResult.IsSuccess)
                _context.CurrentPage = new OrdersPage([]) { Orders = [.. ordersGetResult.Value] };
        }
    }
}
