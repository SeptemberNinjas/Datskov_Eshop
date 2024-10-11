using Eshop.Core;

namespace Eshop.Menu.Commands
{
    internal class ClearCartCommand : IMenuCommand
    {
        public string Description { get; } = "Clear cart";

        public void Execute(MenuPage currentPage)
        {
            ApplicationContext.Cart.Clear();
            currentPage.Show();
        }
    }
}
