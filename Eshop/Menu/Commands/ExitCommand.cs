namespace Eshop.Menu.Commands
{
    internal class ExitCommand : IMenuCommand
    {
        public string Description { get; } = "Exit";

        public void Execute(ApplicationContext app) => Environment.Exit(0);

    }
}
