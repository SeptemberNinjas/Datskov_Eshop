namespace Eshop.Menu.Commands
{
    internal interface IMenuCommand
    {
        public string Description { get; }

        public void Execute();

        public Task ExecuteAsync(CancellationToken ct = default)
        {
            Execute();
            return Task.CompletedTask;
        } 
    }
}
