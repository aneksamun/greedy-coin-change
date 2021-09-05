namespace RedPixel.Vending.Console
{
    using System.IO;
    using System.Reflection;
    using Converter;
    using Core.Supply;
    using Newtonsoft.Json;

    static class InventoryReader
    {
        private const string FileName = 
            "RedPixel.Vending.Console.Inventory.json";
        
        internal static Inventory Read()
        {
            var assembly = Assembly.GetExecutingAssembly();
            
            using (var stream = assembly.GetManifestResourceStream(FileName))
            using (var reader = new StreamReader(stream ?? throw new ResourceNotFoundException(FileName)))
            {
                var json = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<Inventory>(json, new InventoryJsonConverter());
            }
        }
    }
}
