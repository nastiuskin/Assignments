using Assignment_16.Abstractions;
using Assignment_16.Decorators;

namespace Assignment_16
{
    public class TextFormatter
    {
        private string _originalText;
        private IText _text;
        private Stack<IText> _history = new();
        public TextFormatter(IText text)
        {
            _text = text;
            _originalText = _text.GetRawText();
            _history.Push(_text);
        } 
        public void ApplyBold()
        {
            _text = new BoldDecorator(_text);
            _history.Push(_text);
        }

        public void ApplyItalic() 
        {
            _text = new ItalicDecorator(_text);
            _history.Push(_text);
        }

        public void ApplyUnderline()
        {
            _text = new UnderlineDecorator(_text);
            _history.Push(_text);
        } 
        public void ApplyColor(string color)
        {
            _text = new ColorDecorator(_text, color);
            _history.Push(_text);
        }           

        public void ResetFormatting()
        {
            _text = new PlainText(_originalText);
            _history.Clear();
            _history.Push(_text);
        }
        public void Undo()
        {
            if (_history.Count <= 1)
                return;

            _history.Pop();
            _text = _history.Peek();
        }

        public string GetFormattedText() => _text.GetFormattedText();
    }
}
