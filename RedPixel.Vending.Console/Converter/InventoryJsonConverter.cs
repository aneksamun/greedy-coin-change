namespace RedPixel.Vending.Console.Converter
{
    using System;
    using System.Linq;
    using Core.Supply;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    internal class InventoryJsonConverter : JsonConverter
    {
        private const string CoinKey = "coin";
        private const string SizeKey = "size";
        
        public override bool CanConvert(Type objectType)
        {
            return objectType.IsAssignableFrom(typeof(Inventory));
        }
        
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override object ReadJson(JsonReader reader, 
                                        Type objectType, 
                                        object existingValue,
                                        JsonSerializer serializer)
        {
            var supply = JArray.Load(reader);
            return Inventory.Of(supply.Select(ConvertToPack));
        }

        private static Pack ConvertToPack(JToken element)
        {
            var size = element[SizeKey].ToObject<int>();
            var coin = element[CoinKey].ToObject<string>();
            var unit = UnitParser.FromString(coin);
            return Pack.Of(unit, size);
        }
    }
}
