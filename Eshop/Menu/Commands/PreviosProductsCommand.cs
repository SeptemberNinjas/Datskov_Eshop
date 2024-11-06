namespace Eshop.Menu.Commands
{
    internal class PreviosProductsCommand(ApplicationContext context) : IMenuCommand
    {
        public string Description { get; } = "Previos page";

        public void Execute()
        {
            if (context.CurrentPage is CatalogPage catPage && catPage.PageNum > 1)
                catPage.PageNum--;
        }
    }
}
