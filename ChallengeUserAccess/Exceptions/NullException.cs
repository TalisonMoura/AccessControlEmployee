namespace ChallengeUserAccess.Exceptions;

public class NullException : CustomizedException
{
    const string message = "This object doen't exist";
    public NullException(string opt = message) : base(opt)
    {
    }
}
