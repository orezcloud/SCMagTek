namespace MagTek
{
    public class ScannedCheck
    {
        public string CheckNumber { get; set; }
        public string AccountNumber { get; set; }
        public string RoutingNumber { get; set; }
        public byte[] CheckImage { get; set; }
    }
}