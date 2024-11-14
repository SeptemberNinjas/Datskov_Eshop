using Eshop.Application.CartHandlers;
using Eshop.Application.OrderHandlers;

namespace Eshop.Menu.Commands
{
    internal class CreateOrderCommand : IMenuCommand
    {
        private readonly ApplicationContext _context;
        private readonly CreateOrderHandler _createOrderFromCartHandler;
        private readonly ClearCartHandler _clearCartHandler;
        private readonly ShowOrdersCommand _showOrdersCommand;

        public string Description { get; } = "Create order";

        public CreateOrderCommand(ApplicationContext context, 
            CreateOrderHandler createOrderFromCartHandler,
            ClearCartHandler clearCartHandler,
            ShowOrdersCommand showOrdersCommand)
        {
            _context = context;
            _createOrderFromCartHandler = createOrderFromCartHandler;
            _clearCartHandler = clearCartHandler;
            _showOrdersCommand = showOrdersCommand;
        }
        
        public void Execute() => ExecuteAsync().Wait();

        public async Task ExecuteAsync()
        {
            var result = await _createOrderFromCartHandler.CreateOrderFromCartAsync();
            if (result.IsFailed) 
            {
                _context.CurrentPage.InfoMessage = result.Errors[0].Message;
                return;
            }

            result = await _clearCartHandler.ClearCartAsync();
            if (result.IsFailed)
            {
                _context.CurrentPage.InfoMessage = result.Errors[0].Message;
                return;
            }

            await _showOrdersCommand.ExecuteAsync();
        }
    }
}
