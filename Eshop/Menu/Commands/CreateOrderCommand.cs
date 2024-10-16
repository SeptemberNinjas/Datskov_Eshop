namespace Eshop.Menu.Commands
{
    internal class CreateOrderCommand : IMenuCommand
    {
        public string Description { get; } = "Create order";

        public void Execute()
        {
            if (Program.Context.Cart.Count == 0)
            {
                var currentPage = Program.Context.CurrentPage;

                currentPage.InfoMessage = "Cart is empty!";
                return;
            }

            ApplicationContext.Orders.Add(new(ApplicationContext.GetNewOrderNumber(), Program.Context.Cart));
            Program.Context.Cart.Clear();

            new ShowOrdersCommand().Execute();
        }
    }
}
