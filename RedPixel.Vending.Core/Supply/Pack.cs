namespace RedPixel.Vending.Core.Supply
{
    public sealed class Pack
    {
        private Pack(Unit coin, int size)
        {
            Coin = coin;
            Size = size;
        }

        public Unit Coin { get; }
        public int Size { get; set; }

        public override string ToString() => $"{Coin}x{Size}";

        public static Pack Of(Unit coin, int size) => new Pack(coin, size);
    }
}