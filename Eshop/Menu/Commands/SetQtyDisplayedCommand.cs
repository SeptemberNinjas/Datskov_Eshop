namespace Eshop.Menu.Commands
{
    internal class SetQtyDisplayedCommand : IMenuCommand
    {
        public string Description { get; } = "Set qty displayed";

        public void Execute(MenuPage currentPage)
        {
            string? answer;
            int selectedQty;

            do
            {
                Console.Write("Qty (1-5): ");
                answer = Console.ReadLine();
            }
            while (!int.TryParse(answer, out selectedQty) || selectedQty < 1 || selectedQty > 5);

            CatalogPage.ProdQty = selectedQty;
            currentPage.Show();
        }
    }
}
