namespace Eshop.Menu.Commands
{
    internal class BackCommand : IMenuCommand
    {
        public string Description { get; } = "Back";

        public void Execute(ApplicationContext app)
        {
            var currentPage = app.CurrentPage;
            if (currentPage.PreviosPage is not null)
                app.CurrentPage = currentPage.PreviosPage;
        }
    }
}
