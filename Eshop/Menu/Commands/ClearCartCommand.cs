using Eshop.Core;

namespace Eshop.Menu.Commands
{
    internal class ClearCartCommand(Cart cart) : IMenuCommand
    {
        public string Description { get; } = "Clear cart";

        public void Execute() => cart.Clear();
    }
}
