using Assignment_16.Abstractions;

namespace Assignment_16.Decorators
{
    public class ItalicDecorator : TextDecorator
    {
        public ItalicDecorator(IText text) : base(text) { }

        public override string GetFormattedText() => $"<i>{_text.GetFormattedText()}</i>";
        }
    }
