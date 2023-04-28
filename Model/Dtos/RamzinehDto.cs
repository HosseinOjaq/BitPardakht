namespace Domain.Dtos
{
    public class RamzinexDto
    {
        public int status { get; set; }
        public Data data { get; set; }
    }
    public class Data
    {
        public Currencies currencies { get; set; }
        public Usdtirr usdtirr { get; set; }
    }
    public class Usdtirr
    {
        public int sell { get; set; }
        public int buy { get; set; }
    }
}
