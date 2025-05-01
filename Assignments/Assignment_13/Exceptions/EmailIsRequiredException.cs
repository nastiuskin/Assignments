namespace Assignment_13.Exceptions
{
    public class EmailIsRequiredException : Exception
    {
        public EmailIsRequiredException(string message)
            : base(message) { }
    }
}
