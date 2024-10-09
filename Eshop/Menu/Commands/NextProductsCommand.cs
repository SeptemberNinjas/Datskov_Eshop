namespace Eshop.Menu.Commands
{
    class NextProductsCommand : IMenuCommand
    {
        public string Description { get; } = "Next page";

        public void Execute(MenuPage currentPage)
        {
            if (currentPage is CatalogPage catPage)
                catPage.PageNum++;

            currentPage.Show();
        }
    }
}
