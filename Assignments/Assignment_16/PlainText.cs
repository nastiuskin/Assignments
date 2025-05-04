using Assignment_16.Abstractions;

namespace Assignment_16
{
    public class PlainText : IText
    {
        private readonly string _text;
        public PlainText(string text) => _text = text;
        public string GetFormattedText() => _text;
        public string GetRawText() => _text;
    }
}
