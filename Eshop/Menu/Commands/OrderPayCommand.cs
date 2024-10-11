using Eshop.Core;

namespace Eshop.Menu.Commands
{
    internal class OrderPayCommand : IMenuCommand
    {
        public string Description { get; } = "Payment for the order";

        public void Execute(MenuPage currentPage)
        {
            int orderNum;
            {
                string? input;
                do
                {
                    Console.WriteLine("Input order number");
                    input = Console.ReadLine();
                }
                while (!int.TryParse(input, out orderNum) || orderNum == 0);
            }

            var order = ApplicationContext.Orders.Find(x => x.Number == orderNum);
            if (order == null)
                currentPage.InfoMessage = $"Order number {orderNum} not found!";
            else if (order.Status != OrderStatuses.New)
                currentPage.InfoMessage = $"Order number {orderNum} alredy paid!";
            else
            {
                order.SetStatus(OrderStatuses.Paid);
                currentPage.InfoMessage = $"Order number {orderNum} successfully paid!";
            }
            currentPage.Show();
        }
    }
}
