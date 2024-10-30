namespace Eshop.Menu.Commands
{
    internal class ExitCommand : IMenuCommand
    {
        public string Description { get; } = "Exit";

        public void Execute() => Environment.Exit(0);
    }
}
