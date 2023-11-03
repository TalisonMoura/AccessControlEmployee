using System.Text.RegularExpressions;

namespace ChallengeUserAccess.ExtensionFormat;

public static class StringExtension
{
    public static bool IsNumberAndLetters(this string str)
    {
        Regex reg = new(@"^(?=.*[0-9])(?=.*[a-zA-Z]).+$");
        return reg.IsMatch(str);
    }
    public static string RemoveSpecialCharacters(this string str)
    {
        Regex reg = new(@"[^a-zA-Z0-9]");
        return reg.Replace(str, string.Empty);
    }
    public static bool IsNumber(this string str)
    {
        Regex reg = new(@"^-?\d+(\.\d+)?$");
        return reg.IsMatch(str);
    }
    public static bool IsString(this string str)
    {
        Regex reg = new(@"^[A-Za-z]+$");
        return reg.IsMatch(str);
    }
    public static string RemoveNotNumbers(this string value)
    {
        Regex reg = new(@"[^0-9]");
        string ret = reg.Replace(value, string.Empty);
        return ret;
    }
    public static bool EmailValidate(this string str) 
    {
        Regex reg = new(@"^[\w\.-]+@[\w\.-]+\.\w+$");
        return reg.IsMatch(str);
    }
    public static bool PasswordValidate(this string str) 
    {
        Regex reg = new(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*\W).{8,}$");
        return reg.IsMatch(str);
    }

    public static bool PhoneNumberValidate(this string str)
    {
        Regex reg = new(@"\d{11}");
        return reg.IsMatch(str);
    }
}
