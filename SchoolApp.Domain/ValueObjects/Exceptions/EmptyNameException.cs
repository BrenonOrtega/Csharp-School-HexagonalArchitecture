namespace SchoolApp.Domain.ValueObjects.Exceptions
{
    [System.Serializable]
    public class EmptyNameException : System.Exception
    {
        public EmptyNameException() { }
        public EmptyNameException(string message) : base(message) { }
        public EmptyNameException(string message, System.Exception inner) : base(message, inner) { }
        protected EmptyNameException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
    
}