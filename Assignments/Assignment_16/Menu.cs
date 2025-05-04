using Assignment_16.Abstractions;
using Assignment_16.Commands;

namespace Assignment_16
{
    public class Menu
    {
        private readonly List<ICommand> _commands;
        private readonly TextFormatter _formatter;

        public Menu(TextFormatter formatter)
        {
            _formatter = formatter;
            _commands = new List<ICommand>
        {
            new BoldCommand(),
            new ItalicCommand(),
            new ColorCommand(),
            new UndoCommand(),
            new ResetCommand(),
            new ExitCommand()
        };
        }

        public void Show()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Formatted text ===");
                Console.WriteLine(_formatter.GetFormattedText());
                Console.WriteLine("=============================\n");

                for (int i = 0; i < _commands.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {_commands[i].Name}");
                }

                Console.Write("\nChoose an action: ");
                if (int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= _commands.Count)
                {
                    _commands[index - 1].Execute(_formatter);
                }
                else
                {
                    Console.WriteLine("Invalid input");
                    //Console.ReadKey();
                }
            }
        }
    }
}
