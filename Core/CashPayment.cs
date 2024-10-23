namespace Eshop.Core
{
    public class CashPayment : IPaymentMethod
    {
        public decimal PaymentAmount { get; set; }

        public decimal ReceivedCash { get; set; }

        private IPaymentUI? _userInterface;

        public bool MakePayment(IPaymentUI userInterface)
        {
            _userInterface = userInterface;
            ReceiveCash();

            if (!ReceivedAmountEnough())
            {
                _userInterface.InteractionWithClient("Not enough money!");
                return false;
            }

            if (ReceivedCash > PaymentAmount)
                _userInterface.InteractionWithClient($"Take change {ReceivedCash - PaymentAmount} rub.");

            _userInterface.InteractionWithClient("Thank you for choosing Eshop!");

            return true;
        }

        private bool ReceivedAmountEnough()
        {
            return ReceivedCash >= PaymentAmount;
        }

        private void ReceiveCash()
        {
            decimal result = 0.0M;

            _userInterface?.InteractionWithClient("Enter the amount you gave me: ", out result);

            ReceivedCash = result;
        }
    }
}
