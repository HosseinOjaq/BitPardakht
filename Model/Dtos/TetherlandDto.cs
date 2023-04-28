namespace Domain.Dtos
{
    public class TetherlandDto
    {
        public Data data { get; set; }
    }
    public class Currencies
    {
        public USDT USDT { get; set; }
    }
    public class USDT
    {
        public int price { get; set; }
    }
}

