namespace RedPixel.Vending.Core.Supply
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public sealed class Inventory : IEnumerable<Pack>
    {
        private readonly IList<Pack> _packs;

        public Inventory() => _packs = new List<Pack>();

        public Inventory(IEnumerable<Pack> packs) => _packs = new List<Pack>(packs);

        public Pack this[int index] => _packs[index];

        public int Count => _packs.Count;
        
        public void Add(Pack pack) => _packs.Add(pack);

        public IEnumerator<Pack> GetEnumerator() => _packs.GetEnumerator();
        
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        
        public override string ToString() => string.Join(", ", _packs);

        public Inventory Copy() => new Inventory(_packs.Select(pack => Pack.Of(pack.Coin, pack.Size)));

        public static Inventory Of(IEnumerable<Pack> packs) => new Inventory(packs);
    }
}
