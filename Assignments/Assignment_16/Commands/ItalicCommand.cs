using Assignment_16.Abstractions;

namespace Assignment_16.Commands
{
    public class ItalicCommand : ICommand
    {
        public string Name => "Apply Italic";
        public void Execute(TextFormatter textFormatter) => textFormatter.ApplyItalic();
    }
}
