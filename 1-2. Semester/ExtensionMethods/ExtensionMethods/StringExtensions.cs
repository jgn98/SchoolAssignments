namespace ExtensionMethods;

public static class StringExtensions
{

    public static string Shift(this string str, int shift)
    {
        if (string.IsNullOrEmpty(str)) return "";
        
        string result = null;
        int length = str.Length;
        shift %= length;
        
        if (shift > 0)
        {
            string right = str.Substring(length - shift);
            string left = str.Substring(0, length - shift);
            result = right + left;
        }
        if (shift < 0)
        {
            shift = -shift;
            string left = str.Substring(shift);
            string right = str.Substring(0, shift);
            result = left + right;
        }

        if (shift == 0)
        {
            result = str;
        }
        
        return result;
    }
}