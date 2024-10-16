namespace Eshop.Menu.Commands
{
    internal class PreviosProductsCommand : IMenuCommand
    {
        public string Description { get; } = "Previos page";

        public void Execute()
        {
            var currentPage = Program.Context.CurrentPage;

            if (currentPage is CatalogPage catPage && catPage.PageNum > 1)
                catPage.PageNum--;
        }
    }
}
