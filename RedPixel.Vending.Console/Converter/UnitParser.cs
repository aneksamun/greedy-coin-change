namespace RedPixel.Vending.Console.Converter
{
    using System;
    using System.Linq;
    using System.Text.RegularExpressions;
    using Core.Supply;

    internal static class UnitParser
    {
        private static readonly Regex CoinPattern = 
            new Regex(@"^(" + Pound.Symbol + "[0-9]+|[0-9]+" + Pence.Symbol + "){1}$");

        private static readonly string[] Symbols = {Pence.Symbol, Pound.Symbol};

        internal static bool HasValidFormat(string value)
        {
            return CoinPattern.Match(value).Success;
        }

        internal static Unit FromString(string value)
        {
            if (!HasValidFormat(value))
                throw new FormatException(
                    "Illegal coin format. Requires denomination to be provided along with currency symbol, i.e., £1");

            return Symbols.Where(value.Contains)
                          .Select(symbol => Parse(value, symbol))
                          .First();
        }

        private static Unit Parse(string format, string symbol)
        {
            if (!int.TryParse(format.Replace(symbol, ""), out var value))
                throw new InvalidCastException("Denomination is not valid integer value.");

            var denomination = (Denomination) value;

            switch (symbol)
            {
                case Pound.Symbol:
                    return new Pound(denomination);
                case Pence.Symbol:
                    return new Pence(denomination);
                default:
                    throw new NotSupportedException($"The currency symbol '{symbol}' is not supported");
            }
        }
    }
}