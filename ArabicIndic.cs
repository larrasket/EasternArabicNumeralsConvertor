using System.Text;

#pragma warning disable CS8604

namespace Eastern_Arabic_numerals_Convertor;

public static class ArabicIndic
{
    private static readonly List<string> IndicMap = new() {"٠", "١", "٢", "٣", "٤", "٥", "٦", "٧", "٨", "٩", ","};
    private static string[] _arabicMap = {"0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "."};

    private static string Converter(string num)
    {
        var result = new StringBuilder();
        for (int i = 0; i < num.Length; i++)
        {
            if (char.IsDigit(num[i])) result.Append(IndicMap[int.Parse(num[i].ToString())]);
            else result.Append(',');
        }

        return result.ToString();
    }


    private static string Invertor(string num)
    {
        var result = new StringBuilder();
        for (int i = 0; i < num.Length; i++)
        {
            var index = IndicMap.FindIndex(x => x == num[i].ToString());
            result.Append(index == -1 ? "." : _arabicMap[index]);
        }

        return result.ToString();
    }


    public static string ConvertToIndic(object number)
    {
        if (number is null) throw new NullReferenceException();
        if (!number.IsNumber())
        {
            throw new Exception("Input is not a valid number");
        }

        return Converter(number.ToString());
    }


    public static string ConvertToIndic(string number)
    {
        if (number is null) throw new NullReferenceException();

        try
        {
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            double.Parse(number);
        }
        catch (Exception)
        {
            throw new Exception("Input is not a valid number");
        }

        return Converter(number);
    }

    public static string ConvertToArabic(string number)
    {
        if (string.IsNullOrEmpty(number)) throw new NullReferenceException();
        var tmp = number.Any(x => IndicMap.All(f => f != x.ToString()));
        if (tmp) throw new Exception("Non-Indic Input");
        return Invertor(number);
    }


    private static bool IsNumber(this object value)
    {
        return value is sbyte
               || value is byte
               || value is short
               || value is ushort
               || value is int
               || value is uint
               || value is long
               || value is ulong
               || value is float
               || value is double
               || value is decimal;
    }
}