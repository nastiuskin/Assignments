using Assignment_16.Abstractions;

namespace Assignment_16.Decorators
{
    public class UnderlineDecorator : TextDecorator
    {
        public UnderlineDecorator(IText text) : base(text) { }

        public override string GetFormattedText() => $"<u>{_text.GetFormattedText()}</u>";
    }
}
