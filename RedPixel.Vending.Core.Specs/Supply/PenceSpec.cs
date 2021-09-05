namespace RedPixel.Vending.Core.Specs.Supply
{
    using System.Diagnostics.CodeAnalysis;
    using Core.Supply;
    using FluentAssertions;
    using Machine.Specifications;
    using static Core.Supply.Denomination;

    [Subject(typeof(Pence))]
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class when_getting_total_for_pence
    {
        Establish context = () =>
        {
            pence = new Pence(Three);
        };

        Because of = () =>
        {
            total = pence.Total;
        };

        It should_return_value_of_denomination = () =>
        {
            total.Should().Be((int) pence.Denomination);
        };

        static int total;
        static Pence pence;
    }

    [Subject(typeof(Pence))]
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class when_converting_pence_to_string
    {
        Establish context = () =>
        {
            pence = new Pence(Twenty);
        };

        Because of = () =>
        {
            @string = pence.ToString();
        };

        It should_have_pence_symbol_together_with_denomination = () =>
        {
            @string.Should().Be("20p");
        };

        static Pence pence;
        static string @string;
    }
}
