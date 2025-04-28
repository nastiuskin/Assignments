namespace Assignment_10.Exceptions
{
    public class EmptyEmailBodyException : Exception
    {
        public EmptyEmailBodyException(string emailBody) : base(emailBody) { }
    }
}
