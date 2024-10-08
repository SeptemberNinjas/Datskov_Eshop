namespace Eshop.Core
{
    public class Service : Product
    {
        public Service(int Id, string Name) : base(Id, Name)
        {
        }

        public Service(int Id, string Name, string Description) : base(Id, Name, Description)
        {
        }
    }
}
