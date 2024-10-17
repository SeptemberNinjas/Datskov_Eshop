namespace Eshop.Menu.Commands
{
    internal class CreateOrderCommand : IMenuCommand
    {
        public string Description { get; } = "Create order";

        public void Execute(ApplicationContext app)
        {
            if (app.Cart.Count == 0)
            {
                var currentPage = app.CurrentPage;

                currentPage.InfoMessage = "Cart is empty!";
                return;
            }

            app.Orders.Add(new(app.GetNewOrderNumber(), app.Cart));
            app.Cart.Clear();

            new ShowOrdersCommand().Execute(app);
        }
    }
}
