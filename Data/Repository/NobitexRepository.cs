using Data.Contracts;
using Domain.Dtos;
using Newtonsoft.Json;
using System.Diagnostics;

namespace Data.Repository
{
    public class NobitexRepository : IServicePrices<ResultPriceDto?>
    {
        private readonly HttpClient httpClient;
        public NobitexRepository(IHttpClientFactory httpClientFactory)
        {
            httpClient = httpClientFactory.CreateClient();
        }

        public virtual async Task<ResultPriceDto?> GetPrices()
        {
            var result = new NobitexDto();
            try
            {
                var json = await httpClient.GetStringAsync("https://api.nobitex.ir/v2/orderbook/USDTIRT");
                result = JsonConvert.DeserializeObject<NobitexDto>(json);
            }
            catch (Exception e)
            {
                return null;
            }
            var price = float.Parse(result.lastTradePrice) / 10;
            return new ResultPriceDto
            {
                Title = "صرافی نوبیتکس",
                Buy = price,
                Sell = price,
                Link= @"https://nobitex.ir/login/"
            };
        }
    }
}
