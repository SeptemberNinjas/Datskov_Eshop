namespace Eshop.Core
{
    public class OrderCashPayment : IOrderPayment
    {
        public decimal PaymentAmount { get => Order?.TotalAmount ?? 0; }
        public Order? Order { get; set; }
        public decimal ReceivedAmount { get; set; } = 0;

        public void MakePayment(out PaymentResult result)
        {
            result = new();

            if (Order is null)
                result.ResultDescription = "Order not found!";

            if (Order?.Status != OrderStatuses.New)
                result.ResultDescription = $"Order number {Order?.Number} alredy paid!";

            if (PaymentAmount > ReceivedAmount)
                result.ResultDescription = "Not enoght money!";

            if (result.ResultDescription != string.Empty)
                return;

            if (PaymentAmount < ReceivedAmount)
                result.ResultDescription = $"Your change: {ReceivedAmount - PaymentAmount}" + Environment.NewLine;

            result.IsSuccess = true;
            result.ResultDescription += $"Order number {Order?.Number} has been successfully paid!";
        }
    }
}
