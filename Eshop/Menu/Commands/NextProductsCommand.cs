namespace Eshop.Menu.Commands
{
    class NextProductsCommand : IMenuCommand
    {
        public string Description { get; } = "Next page";

        public void Execute(ApplicationContext app)
        {
            var currentPage = app.CurrentPage;

            if (currentPage is CatalogPage catPage)
                catPage.PageNum++;
        }
    }
}
