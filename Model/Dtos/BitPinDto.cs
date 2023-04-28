namespace Domain.Dtos
{
    public class BitPinDto
    {
        public int count { get; set; }
        public object next { get; set; }
        public object previous { get; set; }
        public List<Result> results { get; set; }
    }
    public class Result
    {
        public int id { get; set; }
        public Price_Info price_info { get; set; }
    }
    public class Price_Info
    {
        public string price { get; set; }
    }

}
