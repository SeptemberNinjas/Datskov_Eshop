using Eshop.Core;

namespace Eshop.Menu.Commands
{
    internal class OrderPayCommand : IMenuCommand
    {
        private MenuPage _currentPage = new(null, []);

        private IOrderPayment? _paymentMethod;

        public string Description { get; } = "Payment for the order";

        public void Execute(ApplicationContext app)
        {
            _currentPage = app.CurrentPage;
            _currentPage.GetUserInput("Input order number", out int orderNum);

            var order = app.OrderManager.GetById(orderNum);

            SelectPaymentMethod();
            if (_paymentMethod is not IOrderPayment paymentMethod)
                return;
            
            paymentMethod.Order = order;

            _currentPage.GetUserInput($"Due {paymentMethod.PaymentAmount}, how much money will you give me?", out decimal userInput);

            paymentMethod.ReceivedAmount = userInput;
            paymentMethod.MakePayment(out var result);

            if (result.IsSuccess && order != null)
            {
                order.Status = OrderStatuses.Paid;
                app.OrderManager.Save(order);
                OrdersPage.Orders = [.. app.OrderManager.GetAll()];
            }
            _currentPage.InfoMessage = result.ResultDescription;
        }
        private void SelectPaymentMethod()
        {
            int userInput;
            var inputMessage = "Select payment method:" + Environment.NewLine +
                "   1 - Cash, " + Environment.NewLine +
                "   2 - CashLess ";
            do
                _currentPage.GetUserInput(inputMessage, out userInput);
            while (userInput != 1 && userInput != 2);

            IOrderPayment paymentMethod = userInput switch
            {
                1 => new OrderCashPayment(),
                2 => new OrderCashLessPayment(),
                _ => throw new NotSupportedException()
            };

            _paymentMethod = paymentMethod;
        }
    }
}
