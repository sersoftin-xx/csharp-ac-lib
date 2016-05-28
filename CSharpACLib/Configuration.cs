namespace CSharpACLib
{
    public class Configuration
    {
        public string BaseApiUrl { get; set; }
        public byte[] PublicKeyHash { get; set; }
        public int ProductId { get; set; }
        public string HashSalt { get; set; }
    }
}
