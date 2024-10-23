﻿using Eshop.Menu.Commands;

namespace Eshop.Menu
{
    internal class MenuPage(MenuPage? previosPage, Dictionary<int, IMenuCommand> commands)
    {
        public MenuPage? PreviosPage { get; } = previosPage;
        public string InfoMessage { get; set; } = string.Empty;
        private readonly Dictionary<int, IMenuCommand> _commands = commands;

        public virtual void DrawPage()
        {
            DrawCommandInterface();
        }

        public void DrawCommandInterface()
        {
            foreach (var KeyValue in _commands)
                Console.WriteLine("" + KeyValue.Key + ": " + KeyValue.Value.Description);
            Console.Write("Select action: ");
        }
        public IMenuCommand Show()
        {
            IMenuCommand? selectedCommand;
            string? answer;

            do
            {
                Console.Clear();

                if (InfoMessage != string.Empty)
                {
                    Console.WriteLine(InfoMessage);
                    InfoMessage = string.Empty;
                }
                DrawPage();
                answer = Console.ReadLine();
            }
            while (!int.TryParse(answer, out int selectedAction) || !_commands.TryGetValue(selectedAction, out selectedCommand));

            return selectedCommand;
        }

        public void GetUserInput(string message, out int result)
        {
            string? input;
            do
            {
                Console.WriteLine(message);
                input = Console.ReadLine();
            }
            while (!int.TryParse(input, out result));
        }
        public void GetUserInput(string message, out decimal result)
        {
            string? input;
            do
            {
                Console.WriteLine(message);
                input = Console.ReadLine();
            }
            while (!decimal.TryParse(input, out result));
        }
    }
}
