namespace Eshop.Core
{
    public interface IOrderPayment
    {
        public decimal PaymentAmount { get; }
        public Order? Order { get; set; }
        public decimal ReceivedAmount { get; set; }

        public void MakePayment(out PaymentResult result);
    }
}
