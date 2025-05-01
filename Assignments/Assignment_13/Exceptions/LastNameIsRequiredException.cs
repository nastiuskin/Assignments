namespace Assignment_13.Exceptions
{
    public class LastNameIsRequiredException : Exception
    {
        public LastNameIsRequiredException(string message)
            : base(message) { }
    }
}
