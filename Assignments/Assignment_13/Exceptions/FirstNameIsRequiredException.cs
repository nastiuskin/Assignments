namespace Assignment_13.Exceptions
{
    public class FirstNameIsRequiredException : Exception
    {
        public FirstNameIsRequiredException(string message)
            : base(message) { }
    }
}
