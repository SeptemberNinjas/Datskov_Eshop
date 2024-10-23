namespace Eshop.Core
{
    public class CashLessPayment : IPaymentMethod
    {
        public decimal PaymentAmount { get; set; }

        public bool MakePayment(IPaymentUI userInterafce)
        {
            userInterafce.InteractionWithClient("There are not enough funds on the card!");
            return false;
        }
    }
}
