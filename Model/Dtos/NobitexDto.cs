namespace Domain.Dtos;
public class NobitexDto
{
    public string status { get; set; }
    public long lastUpdate { get; set; }
    public string lastTradePrice { get; set; }
    public string[][] bids { get; set; }
    public string[][] asks { get; set; }
}
