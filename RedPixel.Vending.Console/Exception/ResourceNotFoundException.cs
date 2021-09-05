namespace RedPixel.Vending.Console
{
    using System;

    public class ResourceNotFoundException : Exception
    {
        public ResourceNotFoundException(string fileName) 
            : base($"No resource found under name: {fileName}")
        {
        }
    }
}