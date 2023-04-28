using Data.Contracts;
using Domain.Dtos;
using Newtonsoft.Json;
using System.Diagnostics;

namespace Data.Repository
{
    public class RamzinexRepository : IServicePrices<ResultPriceDto?>
    {
        private readonly HttpClient httpClient;
        public RamzinexRepository(IHttpClientFactory httpClientFactory)
        {
            httpClient = httpClientFactory.CreateClient();
        }

        public virtual async Task<ResultPriceDto?> GetPrices()
        {
            var result = new RamzinexDto();
            try
            {
                var json = await httpClient.GetStringAsync("https://publicapi.ramzinex.com/exchange/api/v1.0/exchange/prices");
                result = JsonConvert.DeserializeObject<RamzinexDto>(json);
            }
            catch (Exception e)
            {
                return null;
            }
            var buy = result.data.usdtirr.buy.ToString();
            var sell = result.data.usdtirr.sell.ToString();
            return new ResultPriceDto
            {
                Title = "صرافی رمزینکس",
                Buy = float.Parse(buy.Substring(0, buy.Length - 1)),
                Sell = float.Parse(sell.Substring(0, sell.Length - 1)),
                Link = @"https://ramzinex.com/exchange/pt/authentication/"
            };
        }
    }
}