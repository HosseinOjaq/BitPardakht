using Data.Contracts;
using Domain.Dtos;
using Newtonsoft.Json;
using System.Diagnostics;

namespace Data.Repository
{
    public class BitPinRepository : IServicePrices<ResultPriceDto?>
    {
        private readonly HttpClient httpClient;
        public BitPinRepository(IHttpClientFactory httpClientFactory)
        {
            httpClient = httpClientFactory.CreateClient();
        }

        public virtual async Task<ResultPriceDto?> GetPrices()
        {
            var result = new BitPinDto();
            try
            {
                var json = await httpClient.GetStringAsync("https://api.bitpin.ir/v1/mkt/currencies/");
                result = JsonConvert.DeserializeObject<BitPinDto>(json);
            }
            catch (Exception e)
            {
                return null;
            }
            var price = result.results.SingleOrDefault(i => i.id == 4)?.price_info?.price ?? "0";
            return new ResultPriceDto
            {
                Title = "صرافی بیت پین",
                Buy = float.Parse(price),
                Sell = float.Parse(price),
                Link = @"https://bitpin.ir/login",
                
            };
        }
    }
}
