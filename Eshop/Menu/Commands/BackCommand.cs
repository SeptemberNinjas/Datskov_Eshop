namespace Eshop.Menu.Commands
{
    internal class BackCommand(ApplicationContext context) : IMenuCommand
    {
        public string Description { get; } = "Back";

        public void Execute()
        {
            context.OpenPages.Pop();
        }
    }
}
