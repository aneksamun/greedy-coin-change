namespace RedPixel.Vending.Core.Specs
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using Core.Supply;
    using FluentAssertions;
    using Machine.Specifications;
    using static Core.Supply.Denomination;

    [Subject(typeof(Change))]
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class when_converting_change_to_string
    {
        Establish context = () =>
        {
            change = Change.Of(
                (new Pence(Fifty), 10),
                (new Pound(One), 5)
            );
        };

        Because of = () => { @string = change.ToString(); };

        It should_display_sequence_of_dispensed_coins = () => { @string.Should().Be("50px10, £1x5"); };

        static string @string;
        static Change change;
    }

    [Subject(typeof(Change))]
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class when_adding_new_coin
    {
        Establish context = () =>
        {
            pence = new Pence(One);
            change = new Change();
        };

        Because of = () => { change.Merge(pence); };

        It should_have_coin_added_with_size_of_one = () => { change.Should().HaveCount(1).And.ContainKey(pence); };

        static Change change;
        static Unit pence;
    }

    [Subject(typeof(Change))]
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class when_adding_existing_coin
    {
        Establish context = () =>
        {
            pence = new Pence(One);
            change = Change.Of((pence, 1));
        };

        Because of = () => { change.Merge(pence); };

        It should_increase_size_of_coin = () =>
        {
            change.Should().HaveCount(1).And.Contain(new KeyValuePair<Unit, int>(pence, 2));
        };

        static Change change;
        static Unit pence;
    }
}
