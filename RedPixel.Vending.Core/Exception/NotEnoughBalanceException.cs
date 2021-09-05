namespace RedPixel.Vending.Core.Exception
{
    using System;

    public class NotEnoughBalanceException : Exception
    {
        public NotEnoughBalanceException() 
            : base("Not enough balance to perform an operation.")
        {
        }
    }
}