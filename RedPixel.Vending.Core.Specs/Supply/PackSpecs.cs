namespace RedPixel.Vending.Core.Specs.Supply
{
    using Machine.Specifications;
    using RedPixel.Vending.Core.Supply;
    using System.Diagnostics.CodeAnalysis;
    using FluentAssertions;
    using static Core.Supply.Denomination;

    [Subject(typeof(Pack))]
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    class when_converting_pack_to_string
    {
        Establish context = () =>
        {
            pack = Pack.Of(new Pence(Fifty), 3);
        };

        Because of = () =>
        {
            @string = pack.ToString();
        };

        It should_have_coin_and_count_concatenated = () =>
        {
            @string.Should().Be("50px3");
        };

        static Pack pack;
        static string @string;
    }
}
