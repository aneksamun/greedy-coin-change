namespace RedPixel.Vending.Core
{
    using Exception;
    using Supply;

    public sealed class VendingMachine
    {
        private Inventory _inventory;

        private VendingMachine(Inventory inventory)
        {
            _inventory = inventory;
        }

        public Change Dispense(int amount)
        {
            var inventory = _inventory.Copy();
            var change = new Change();
            
            for (var index = inventory.Count - 1; index >= 0; index--)
            {
                var pack = inventory[index];
                var total = pack.Coin.Total;
                
                while (pack.Size > 0 && total <= amount)
                {
                    amount -= total;
                    change.Merge(pack.Coin);
                    pack.Size--;
                }
                
                if (amount == 0)
                    break;
            }

            if (amount > 0)
                throw new NotEnoughBalanceException();
            
            _inventory = inventory;
            
            return change;
        }

        #region Utils

        public static VendingMachine Craft(Inventory inventory)
        {
            return new VendingMachine(inventory);
        }

        #endregion
    }
}
