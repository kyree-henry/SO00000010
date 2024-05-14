namespace SO00000010.Domain.Exceptions
{
    public class SO00000010Exception : Exception
    {
        public SO00000010Exception(string message) : base(message)
        { }

        public SO00000010Exception(string message, Exception innerException) : base (message, innerException)
        { }
    }
}