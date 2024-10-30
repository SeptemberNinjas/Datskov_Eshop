namespace Eshop.Menu.Commands
{
    class NextProductsCommand(ApplicationContext context) : IMenuCommand
    {
        public string Description { get; } = "Next page";

        public void Execute()
        {
            if (context.CurrentPage is CatalogPage catPage)
                catPage.PageNum++;
        }
    }
}
