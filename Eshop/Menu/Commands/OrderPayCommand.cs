using Eshop.Core;

namespace Eshop.Menu.Commands
{
    internal class OrderPayCommand : IMenuCommand
    {
        public string Description { get; } = "Payment for the order";

        public void Execute(MenuPage currentPage)
        {
            currentPage.GetUserInput("Input order number", out int orderNum);
            
            var order = ApplicationContext.Orders.Find(x => x.Number == orderNum);
            if (order == null)
                currentPage.InfoMessage = $"Order number {orderNum} not found!";
            else if (order.Status != OrderStatuses.New)
                currentPage.InfoMessage = $"Order number {orderNum} alredy paid!";
            else
            {
                order.Status = OrderStatuses.Paid;
                currentPage.InfoMessage = $"Order number {orderNum} successfully paid!";
            }
            currentPage.Show();
        }
    }
}
