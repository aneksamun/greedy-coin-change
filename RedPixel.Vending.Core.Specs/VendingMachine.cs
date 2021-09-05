namespace RedPixel.Vending.Core.Specs
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using Core.Supply;
    using Exception;
    using FluentAssertions;
    using Machine.Specifications;
    using static Core.Supply.Denomination;

    [Subject(typeof(VendingMachine))]
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class when_not_enough_balance
    {
        Establish context = () =>
        {
            inventory = Inventory.Of(new[] {Pack.Of(new Pence(One), 5)});
            vendingMachine = VendingMachine.Craft(inventory);
        };

        Because of = () =>
            notEnoughBalanceException = Catch.Only<NotEnoughBalanceException>(() => vendingMachine.Dispense(41));

        It should_throw_not_enough_argument_exception = () =>
            notEnoughBalanceException.Should().NotBeNull();

        It should_not_modify_balance = () => inventory.Any().Should().BeTrue();

        static Inventory inventory;
        static VendingMachine vendingMachine;
        static NotEnoughBalanceException notEnoughBalanceException;
    }

    [Subject(typeof(VendingMachine))]
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class when_dispensing_amount
    {
        Establish context = () =>
        {
            vendingMachine = VendingMachine.Craft(Inventory.Of(new[]
            {
                Pack.Of(new Pence(One), 1),
                Pack.Of(new Pence(Two), 5),
                Pack.Of(new Pence(Twenty), 1), 
                Pack.Of(new Pence(Five), 2),
                Pack.Of(new Pence(Fifty), 1), 
                Pack.Of(new Pound(Five), 1), 
                Pack.Of(new Pound(Twenty), 1),
                Pack.Of(new Pound(Fifty), 2)
            }));
        };

        Because of = () => actual = 
            cases.Values.Select(amount => vendingMachine.Dispense(amount)).ToList();

        It should_expense_correct_change = () => 
            actual.All(change => cases.ContainsKey(change)).Should().BeTrue(); 

        static IList<Change> actual;
        static VendingMachine vendingMachine;

        static IDictionary<Change, int> cases = new Dictionary<Change, int>
        {
            {Change.Of((new Pence(Five), 1)), 5},
            {Change.Of(
                (new Pound(Fifty), 2), 
                (new Pound(Twenty), 1),
                (new Pence(Five), 1),
                (new Pence(Two), 1),
                (new Pence(One), 1)), 12008},
            {Change.Of(
                (new Pound(Five), 1),
                (new Pence(Fifty), 1),
                (new Pence(Twenty), 1),
                (new Pence(Two), 4)), 578},
            {new Change(), 0}
        };
    }
}
