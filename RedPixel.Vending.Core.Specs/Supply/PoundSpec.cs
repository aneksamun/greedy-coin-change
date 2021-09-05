namespace RedPixel.Vending.Core.Specs.Supply
{
    using System.Diagnostics.CodeAnalysis;
    using Core.Supply;
    using FluentAssertions;
    using Machine.Specifications;
    using static Core.Supply.Denomination;

    [Subject(typeof(Pound))]
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class when_getting_total_for_pound
    {
        Establish context = () =>
        {
            pound = new Pound(Ten);
        };

        Because of = () =>
        {
            total = pound.Total;
        };

        It should_return_total_pence_count = () =>
        {
            total.Should().Be((int) pound.Denomination * 100);
        };

        static int total;
        static Pound pound;
    }

    [Subject(typeof(Pound))]
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class when_converting_pound_to_string
    {
        Establish context = () =>
        {
            pound = new Pound(Ten);
        };

        Because of = () =>
        {
            @string = pound.ToString();
        };

        It should_have_pound_symbol_together_with_denomination = () =>
        {
            @string.Should().Be("£10");
        };

        static Pound pound;
        static string @string;
    }
}
