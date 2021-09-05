namespace RedPixel.Vending.Core.Supply
{
    using System;

    public abstract class Unit : IEquatable<Unit>
    {
        protected Unit(Denomination denomination, Currency currency)
        {
            Denomination = denomination;
            Currency = currency;
        }

        public Denomination Denomination { get; }
        public Currency Currency { get; }
        public abstract int Total { get; }
        
        public bool Equals(Unit other)
        {
            if (ReferenceEquals(null, other)) 
                return false;
            if (ReferenceEquals(this, other)) 
                return true;
            return Denomination == other.Denomination && Currency == other.Currency;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) 
                return false;
            if (ReferenceEquals(this, obj)) 
                return true;
            return obj.GetType() == GetType() && Equals((Unit) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((int) Denomination * 397) ^ (int) Currency;
            }
        }
    }
}
