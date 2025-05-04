using Assignment_16.Abstractions;

namespace Assignment_16.Decorators
{
    public class BoldDecorator : TextDecorator
    {
        public BoldDecorator(IText text) : base(text) { }

        public override string GetFormattedText() => $"<b>{_text.GetFormattedText()}</b>";
    }
}
