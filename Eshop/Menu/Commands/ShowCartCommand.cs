using Eshop.Core;

namespace Eshop.Menu.Commands
{
    internal class ShowCartCommand : IMenuCommand
    {
        public string Description { get; } = "Show cart";

        public void Execute(MenuPage currentPage)
        {
            var cartPage = new CartPage(currentPage, []) { Cart = ApplicationContext.Cart};
            cartPage.Show();
        }
    }
}
