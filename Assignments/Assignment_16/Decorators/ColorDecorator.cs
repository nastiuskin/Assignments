using Assignment_16.Abstractions;

namespace Assignment_16.Decorators
{
    public class ColorDecorator : TextDecorator
    {
        private readonly string _color;
        public ColorDecorator(IText text, string color) : base(text)
        {
            _color = color;
        }

        public override string GetFormattedText() => $"<span style='color:{_color}'>{_text.GetFormattedText()}</span>";
    }
}
