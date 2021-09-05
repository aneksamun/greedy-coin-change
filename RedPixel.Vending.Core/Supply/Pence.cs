namespace RedPixel.Vending.Core.Supply
{
    public class Pence : Unit
    {
        public const string Symbol = "p";
        
        public Pence(Denomination denomination) 
            : base(denomination, Currency.Gbx) {}

        public override int Total => (int) Denomination;
        
        public override string ToString() => $"{(int) Denomination}{Symbol}";
    }
}
