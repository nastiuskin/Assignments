namespace Assignment_13.Exceptions
{
    public class NoSessionsApprovedException : Exception
    {
        public NoSessionsApprovedException(string message)
            : base(message) { }
    }
}
