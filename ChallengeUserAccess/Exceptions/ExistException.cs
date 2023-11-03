namespace ChallengeUserAccess.Exceptions;

public class ExistException : CustomizedException
{
    const string ErrorMessage = "This object already exist";
    public ExistException(string opt = ErrorMessage) : base(opt) { }
}
