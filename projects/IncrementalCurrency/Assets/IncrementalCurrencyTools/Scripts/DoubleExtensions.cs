using System;

public static class DoubleExtensions
{
    public static string ToPrettyString(this double number)
    {
        // negative or between 0 and 1 number not handled yet
        if (number < 1) return "0";

        string prettyNumber = string.Empty;

        // split double scientific notation into exponent and mantissa
        var doubleArray = number.ToString("E").Split(new[] { 'E', '+' });
        var mantissaStr = doubleArray[0];
        var mantissa = double.Parse(mantissaStr);
        var exp = int.Parse(doubleArray[2]);

        // if number is less than 1000, i'll print it as is
        // if not i'll make it prettier
        if (exp < 3)
        {
            prettyNumber = number.ToString("F0");
        }
        else
        {
            // store information about exponent for later uses
            var remainder = exp % 3;
            var magnitude = exp / 3;

            // in case the given number is a multiple of 1000
            // just print the mantissa with only 3 digits after the point with the proper suffix
            // if not multiple of 1000
            // format mantissa moving the point of as many positions as the remainder, then print it with the proper suffix
            if (remainder == 0)
            {
                prettyNumber = string.Format("{0}{1}", double.Parse(mantissaStr).ToString("0.###"), GetLetter(magnitude));
            }
            else
            {
                var mantissaNew = mantissa * Math.Pow(10, remainder);
                prettyNumber = string.Format("{0}{1}", mantissaNew.ToString("0.###"), GetLetter(magnitude));
            }
        }

        return prettyNumber;
    }

    public static string GetLetter(int number)
    {
        return Enum.GetName(typeof(DigitSuffix), number);
    }

    public enum DigitSuffix
    {
        NONE,
        K,
        M,
        B,
        T,
        q,
        Q,
        s,
        S,
        o,
        N,
        d,
        U,
        D,
        Td,
        qd,
        Qd,
        sd,
        Sd,
        od,
        Nd,
        dd
    }
}