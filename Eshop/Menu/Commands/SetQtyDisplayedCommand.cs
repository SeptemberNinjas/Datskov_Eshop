namespace Eshop.Menu.Commands
{
    internal class SetQtyDisplayedCommand : IMenuCommand
    {
        public string Description { get; } = "Set qty displayed";

        public void Execute(MenuPage currentPage)
        {
            int selectedQty;
            
            do
                currentPage.GetUserInput("Qty (1-5): ", out selectedQty);
            while (selectedQty < 1 || selectedQty > 5);

            CatalogPage.ProdQty = selectedQty;
            currentPage.Show();
        }
    }
}
