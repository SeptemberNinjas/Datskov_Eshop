using Eshop.Menu.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Eshop.Menu
{
    internal class MenuPage(MenuPage? previosPage, Dictionary<int, IMenuCommand> commands)
    {
        public MenuPage? PreviosPage { get; } = previosPage;
        private readonly Dictionary<int, IMenuCommand> commands = commands;

        public virtual void DrawPage()
        {
            Console.Clear();
            DrawCommandInterface();
        }

        public void DrawCommandInterface()
        {
            foreach (var KeyValue in this.commands)
                Console.WriteLine("" + KeyValue.Key + ": " + KeyValue.Value.Description);
            Console.Write("Select action: ");
        }
        public void Show()
        {
            IMenuCommand? selectedCommand;
            string? answer;

            do
            {
                this.DrawPage();
                answer = Console.ReadLine();
            }
            while (!int.TryParse(answer, out int selectedAction) || !commands.TryGetValue(selectedAction, out selectedCommand));

            selectedCommand.Execute(this);
        }
    }
}
