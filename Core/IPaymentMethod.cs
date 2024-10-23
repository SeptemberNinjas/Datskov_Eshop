namespace Eshop.Core
{
    public interface IPaymentMethod
    {
        public decimal PaymentAmount { get; set; }

        public bool MakePayment(IPaymentUI userInterafce);
    }
}
