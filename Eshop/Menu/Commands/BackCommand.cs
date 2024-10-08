namespace Eshop.Menu.Commands
{
    internal class BackCommand : IMenuCommand
    {
        public string Description { get; } = "Back";

        public void Execute(MenuPage currentPage)
        {
            MenuPage? previosPage = currentPage.PreviosPage;
            previosPage?.Show();
        }
    }
}
