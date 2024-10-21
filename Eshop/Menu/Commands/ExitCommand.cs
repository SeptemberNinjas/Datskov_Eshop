namespace Eshop.Menu.Commands
{
    internal class ExitCommand : IMenuCommand
    {
        public string Description { get; } = "Exit";

        public void Execute(ApplicationContext app)
        {
            app.BeforeExit();
            Environment.Exit(0);
        } 
    }
}
