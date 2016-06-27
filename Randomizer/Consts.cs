namespace Randomizer
{
    public static class Consts
    {
        public const string MinMaxValueExceptionMsg = "Min value must be less than max.";
        public const string PassedParameterEqualMsg = "Passed min and max are equal!";

        public const string Lowercase = "abcdefghijklmnopqrstuvwxyz";
        public const string Uppercase = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        public const string Numbers = "0123456789";

        public static string AlphanumericCharacters => string.Concat(Uppercase, Lowercase, Numbers);

        public static char[] AlphanumericCharArray => AlphanumericCharacters.ToCharArray();

        public static string Digits => Numbers;

        public static string UppercaseLetters => Uppercase;

        public static string LowercaseLetters => Lowercase;
    }
}
