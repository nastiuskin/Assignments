using Assignment_16.Abstractions;

namespace Assignment_16.Decorators
{
    public abstract class TextDecorator : IText
    {
        protected IText _text;

        protected TextDecorator(IText text) => _text = text;

        public abstract string GetFormattedText();
        public string GetRawText() => _text.GetRawText();
    }
}
