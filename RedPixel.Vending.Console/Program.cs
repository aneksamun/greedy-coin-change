namespace RedPixel.Vending.Console
{
    using System;
    using Core;
    using static System.Console;

    public class Program
    {
        private static volatile bool _exit;
        
        public static void Main()
        {
            CancelKeyPress += (sender, args) =>
            {
                WriteLine("\nBye");
                _exit = true;
            };
            
            WriteLine("Welcome to vending machine!\n");
            WriteLine("Press Ctrl+C to exit...\n");

            try
            {
                var inventory = InventoryReader.Read();
                var vendingMachine = VendingMachine.Craft(inventory);
                
                do
                {
                    Write("Enter amount: ");
                    var input = ReadLine();

                    if (!int.TryParse(input, out var amount))
                    {
                        WriteLine("Please provide valid integer.\n");
                        continue;
                    }

                    var change = vendingMachine.Dispense(amount);
                    WriteLine("Optimal change: {0}\n", change);
                                    
                } while (!_exit);
            }
            catch (Exception exception)
            {
                WriteLine("An error occurred: {0}", exception.Message);
            }
        }
    }
}