namespace Eshop.Core
{
    public class Service
    {
        public int Id { get; }
        public string Name { get; set; }
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }

        public Service(int Id, string Name, decimal Price)
        {
            this.Id = Id;
            this.Name = Name;
            this.Price = Price;
        }
        public Service(int Id, string Name, decimal Price, string Description) : this(Id, Name, Price)
        {
            this.Description = Description;
        }
    }
}
