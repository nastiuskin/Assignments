namespace Assignment_16.Abstractions
{
    interface ICommand
    {
        string Name {  get; }
        void Execute(TextFormatter formatter);
    }
}
