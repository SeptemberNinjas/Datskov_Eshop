namespace Eshop.Menu.Commands
{
    internal class BackCommand : IMenuCommand
    {
        public string Description { get; } = "Back";

        public void Execute()
        {
            var currentPage = Program.Context.CurrentPage;
            if (currentPage.PreviosPage is not null)
                Program.Context.CurrentPage = currentPage.PreviosPage;
        }
    }
}
