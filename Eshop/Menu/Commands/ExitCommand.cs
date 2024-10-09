namespace Eshop.Menu.Commands
{
    internal class ExitCommand : IMenuCommand
    {
        public string Description { get; } = "Exit";

        public void Execute(MenuPage currentPage) => Environment.Exit(0);
    }
}
