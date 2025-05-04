using Assignment_16.Abstractions;

namespace Assignment_16.Commands
{
    public class UndoCommand : ICommand
    {
        public string Name => "Undo previous action";
        public void Execute(TextFormatter textFormatter) => textFormatter.Undo();
    }
}
