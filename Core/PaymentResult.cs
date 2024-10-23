namespace Eshop.Core
{
    public class PaymentResult
    {
        public bool IsSuccess { get; set; } = false;

        public string ResultDescription { get; set; } = string.Empty;
    }
}
