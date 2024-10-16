namespace Eshop.Menu.Commands
{
    class NextProductsCommand : IMenuCommand
    {
        public string Description { get; } = "Next page";

        public void Execute()
        {
            var currentPage = Program.Context.CurrentPage;

            if (currentPage is CatalogPage catPage)
                catPage.PageNum++;
        }
    }
}
