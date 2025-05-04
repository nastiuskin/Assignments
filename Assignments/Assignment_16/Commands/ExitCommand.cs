using Assignment_16.Abstractions;

namespace Assignment_16.Commands
{
    public class ExitCommand : ICommand
    {
        public string Name => "Exit";
        public void Execute(TextFormatter textFormatter) => Environment.Exit(0);
    }
}
