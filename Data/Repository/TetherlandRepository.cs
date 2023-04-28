using Data.Contracts;
using Domain.Dtos;
using Newtonsoft.Json;
using System.Diagnostics;

namespace Data.Repository
{
    public class TetherlandRepository : IServicePrices<ResultPriceDto?>
    {
        private readonly HttpClient httpClient;
        public TetherlandRepository(IHttpClientFactory httpClientFactory)
        {
            httpClient = httpClientFactory.CreateClient();
        }

        public virtual async Task<ResultPriceDto?> GetPrices()
        {
            var result = new TetherlandDto();
            try
            {
                var json = await httpClient.GetStringAsync("https://api.tetherland.com/currencies");
                result = JsonConvert.DeserializeObject<TetherlandDto>(json);
            }
            catch (Exception e)
            {
                return null;
            }
            return new ResultPriceDto
            {
                Title = "صرافی تترلند",
                Buy = result.data.currencies.USDT.price,
                Sell = result.data.currencies.USDT.price,
                Link= @"https://tetherland.com/login"
            };
        }
    }
}
