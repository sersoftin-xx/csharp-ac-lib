namespace CSharpACLib.Hardware
{
    class Baseboard
    {
        public string Manufacturer { get; set; }
        public string Product { get; set; }
        public string SerialNumber { get; set; }

        public string GetHash()
        {
            return Util.Sha256($"{Manufacturer}:{Product}:{SerialNumber}");
        }
    }
}
