namespace Domain.Dtos
{
    public class ResultPriceDto
    {
        public string Title { get; set; }
        public float Buy { get; set; }
        public float Sell { get; set; }
        public string Tax { get; set; } = "1%";
        public string Link { get; set; }
    }
}
