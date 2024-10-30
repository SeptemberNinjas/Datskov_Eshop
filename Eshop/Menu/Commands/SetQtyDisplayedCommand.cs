namespace Eshop.Menu.Commands
{
    internal class SetQtyDisplayedCommand(ApplicationContext context) : IMenuCommand
    {
        public string Description { get; } = "Set qty displayed";

        public void Execute()
        {
            int selectedQty;
            do
                context.CurrentPage.GetUserInput("Qty (1-5): ", out selectedQty);
            while (selectedQty < 1 || selectedQty > 5);

            CatalogPage.ProdQty = selectedQty;
        }
    }
}
