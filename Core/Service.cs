namespace Eshop.Core
{
    public class Service
    {
        public int Id { get; }
        public string Name { get; set; }
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public uint Stock { get; set; }

        public Service(int Id, string Name)
        {
            this.Id = Id;
            this.Name = Name;
        }
        public Service(int Id, string Name, string Description) : this(Id, Name)
        {
            this.Description = Description;
        }
    }
}
