namespace Eshop.Menu.Commands
{
    internal interface IMenuCommand
    {
        public string Description { get; }

        public void Execute(ApplicationContext app);
    }
}
