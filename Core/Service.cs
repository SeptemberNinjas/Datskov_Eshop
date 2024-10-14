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
        public void Deconstruct(out Dictionary<string, string> descriptionData)
        {
            descriptionData = new()
            {
                { "Id", Id.ToString() },
                { "Name", Name },
                { "Price", Price.ToString() },
                { "Description", Description }
            };
        }
    }
}
