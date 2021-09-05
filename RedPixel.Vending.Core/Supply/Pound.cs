namespace RedPixel.Vending.Core.Supply
{
    public class Pound : Unit
    {
        public const string Symbol = "£";
        
        public Pound(Denomination denomination) 
            : base(denomination, Currency.Gbp) {}

        public override int Total => (int) Denomination * 100;
        
        public override string ToString() => $"{Symbol}{(int) Denomination}";
    }
}
