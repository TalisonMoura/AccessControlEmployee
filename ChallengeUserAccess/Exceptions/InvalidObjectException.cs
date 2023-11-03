namespace ChallengeUserAccess.Exceptions
{
    public class InvalidObjectException : CustomizedException
    {
        const string message = "This is not a valid object value";
        public InvalidObjectException(string opt = message) : base(opt) { }
    }
}
