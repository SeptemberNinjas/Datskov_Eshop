namespace Eshop.Core
{
    public class OrderCashLessPayment : IOrderPayment
    {
        public decimal PaymentAmount { get => Order?.TotalAmount ?? 0; }
        public Order? Order { get; set; }
        public decimal ReceivedAmount { get; set; } = 0;

        public void MakePayment(out PaymentResult result)
        {
            result = new();

            if (Order != null)
                result.ResultDescription = "Order not found!";

            if (Order?.Status != OrderStatuses.New)
                result.ResultDescription = $"Order number {Order?.Number} alredy paid!";

            if (PaymentAmount > ReceivedAmount)
                result.ResultDescription = "Not enoght money!";

            if (PaymentAmount < ReceivedAmount)
                result.ResultDescription = "Received too much money!";

            if (result.ResultDescription != string.Empty)
                return;
            
            result.IsSuccess = true;
            result.ResultDescription = $"Order number {Order?.Number} has been successfully paid!";
        }
    }
}
