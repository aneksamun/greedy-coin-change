namespace RedPixel.Vending.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Supply;
    using static System.Array;

    public sealed class Change : Dictionary<Unit, int>, IEquatable<Change>
    {
        public void Merge(Unit unit)
        {
            if (TryGetValue(unit, out var value))
            {
                this[unit] = ++value;
            }
            else
            {
                Add(unit, ++value);   
            }
        }

        public override string ToString()
        {
            return string.Join(", ", Keys.Select(key => $"{key}x{this[key]}"));
        }

        public static Change Of(params (Unit, int)[] pairs)
        {
            var change = new Change();
            ForEach(pairs, pair => change[pair.Item1] = pair.Item2);
            return change;
        }

        public bool Equals(Change other)
        {
            if (ReferenceEquals(null, other))
                return false;
            if (ReferenceEquals(this, other))
                return true;
            return this.All(pair => other.Any(otherPair => otherPair.Key.Equals(pair.Key) && 
                                                           otherPair.Value == pair.Value));
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
                return false;
            if (ReferenceEquals(this, obj))
                return true;
            return obj is Change other && Equals(other);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return this.Aggregate(0, (current, next) => (next.Value * 397) ^ next.Key.GetHashCode());
            }
        }
    }
}
