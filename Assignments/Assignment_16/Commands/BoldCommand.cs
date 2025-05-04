using ICommand = Assignment_16.Abstractions.ICommand;

namespace Assignment_16.Commands
{
    public class BoldCommand : ICommand
    {
        public string Name => "Apply Bold";
        public void Execute(TextFormatter textFormatter) => textFormatter.ApplyBold();
    }
}
