namespace CSharpACLib.Hardware
{
    class SystemEnclosure
    {
        public string Manufacturer { get; set; }
        public string SerialNumber { get; set; }

        public string GetHash()
        {
            return Util.Sha256($"{Manufacturer}:{SerialNumber}");
        }
    }
}
