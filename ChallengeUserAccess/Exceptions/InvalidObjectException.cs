namespace ChallengeUserAccess.Exceptions
{
    public class InvalidObjectException : ApplicationException
    {
        public InvalidObjectException(string opt) : base(opt) { }
    }
}
