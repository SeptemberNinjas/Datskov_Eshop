namespace Eshop.Core
{
    public interface IPaymentUI
    {
        void InteractionWithClient(string message);
        void InteractionWithClient(string message, out int result);
        void InteractionWithClient(string message, out decimal result);
    }
}
