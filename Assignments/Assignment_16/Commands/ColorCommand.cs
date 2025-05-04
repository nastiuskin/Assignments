using Assignment_16.Abstractions;

namespace Assignment_16.Commands
{
    public class ColorCommand : ICommand
    {
        public string Name => "Apply Color";
        public void Execute(TextFormatter textFormatter)
        {
            Console.WriteLine("Enter a color:");
            var color = Console.ReadLine();
            
            if(color != null) 
                textFormatter.ApplyColor(color);
        }
    }
}
