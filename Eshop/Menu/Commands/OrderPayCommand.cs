using Eshop.Core;

namespace Eshop.Menu.Commands
{
    internal class OrderPayCommand : IMenuCommand, IPaymentUI
    {
        private MenuPage _currentPage = new(null, []);

        public string Description { get; } = "Payment for the order";

        public void Execute()
        {
            _currentPage = Program.Context.CurrentPage;
            _currentPage.GetUserInput("Input order number", out int orderNum);

            var order = ApplicationContext.Orders.Find(x => x.Number == orderNum);
            if (order == null)
                _currentPage.InfoMessage = $"Order number {orderNum} not found!";
            else if (order.Status != OrderStatuses.New)
                _currentPage.InfoMessage = $"Order number {orderNum} alredy paid!";
            else
            {
                SelectPaymentMethod();
                if (Program.Context.PaymentMethod is IPaymentMethod paymentMethod)
                {
                    paymentMethod.PaymentAmount = order.TotalAmount;

                    if (paymentMethod.MakePayment(this))
                    {
                        order.Status = OrderStatuses.Paid;
                        _currentPage.InfoMessage += $"Order number {orderNum} was successfully paid!";
                    }
                    else
                        _currentPage.InfoMessage += $"Something went wrong!";
                }
            }
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

            IPaymentMethod paymentMethod = userInput switch
            {
                1 => new CashPayment(),
                2 => new CashLessPayment(),
                _ => new CashPayment()
            };

            Program.Context.PaymentMethod = paymentMethod;
        }
        public void InteractionWithClient(string message) => _currentPage.InfoMessage += message + Environment.NewLine;

        public void InteractionWithClient(string message, out int result) => _currentPage.GetUserInput(message, out result);

        public void InteractionWithClient(string message, out decimal result) => _currentPage.GetUserInput(message, out result);
    }
}
