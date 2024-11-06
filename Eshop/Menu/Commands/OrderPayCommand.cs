using Eshop.Core;

namespace Eshop.Menu.Commands
{
    internal class OrderPayCommand(ApplicationContext context, IRepository<Order> orderRepository) : IMenuCommand
    {
        
        private IOrderPayment? paymentMethod;

        public string Description { get; } = "Payment for the order";

        public void Execute() => ExecuteAsync().Wait();
        
        public async Task ExecuteAsync() 
        {
            var currentPage = context.CurrentPage;

            currentPage.GetUserInput("Input order number", out int orderNum);

            var order = await orderRepository.GetByIdAsync(orderNum)!;

            SelectPaymentMethod();
            if (paymentMethod is null)
                return;

            paymentMethod.Order = order;

            currentPage.GetUserInput($"Due {paymentMethod.PaymentAmount}, how much money will you give me?", out decimal userInput);

            paymentMethod.ReceivedAmount = userInput;
            paymentMethod.MakePayment(out var result);

            if (result.IsSuccess && order != null)
            {
                order.Status = OrderStatuses.Paid;
                await orderRepository.SaveAsync(order);
                if (currentPage is OrdersPage ordPage)
                    ordPage.Orders = [.. await orderRepository.GetAllAsync()];
            }
            currentPage.InfoMessage = result.ResultDescription;
        }

        private void SelectPaymentMethod()
        {
            int userInput;
            var inputMessage = "Select payment method:" + Environment.NewLine +
                "   1 - Cash, " + Environment.NewLine +
                "   2 - CashLess ";
            do
                context.CurrentPage.GetUserInput(inputMessage, out userInput);
            while (userInput != 1 && userInput != 2);

            IOrderPayment paymentMethod = userInput switch
            {
                1 => new OrderCashPayment(),
                2 => new OrderCashLessPayment(),
                _ => throw new NotSupportedException()
            };

            this.paymentMethod = paymentMethod;
        }
    }
}
