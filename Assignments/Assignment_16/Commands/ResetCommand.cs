using Assignment_16.Abstractions;

namespace Assignment_16.Commands
{
    public class ResetCommand : ICommand
    {
        public string Name => "Reset formattings";
        public void Execute(TextFormatter textFormatter) => textFormatter.ResetFormatting();    
    }
}
