using Data.Contracts;
using Domain.Dtos;
using System.Collections.Concurrent;

namespace Data
{
    public class PriceAccessWrapper : IPriceAccessWrapperRepository
    {
        private readonly IHttpClientFactory httpClentFactory;
        public PriceAccessWrapper(IHttpClientFactory httpClientFactory)
        {
            httpClentFactory = httpClientFactory;
        }

        public async Task<List<ResultPriceDto?>> GetPrices(CancellationToken cancellationToken)
        {
            var result = new ConcurrentBag<ResultPriceDto?>();
            var interfaceOfServicetype = typeof(IServicePrices<ResultPriceDto?>);
            var accountTypes = AppDomain.CurrentDomain.GetAssemblies().SelectMany(s => s.GetTypes())
                               .Where(p => interfaceOfServicetype.IsAssignableFrom(p) && p.IsClass);
            
            var options = new ParallelOptions { MaxDegreeOfParallelism = 5, CancellationToken = cancellationToken };
            await Parallel.ForEachAsync(accountTypes, options, async (account, cancellationToken) =>
            {
                var accountInstance = Activator.CreateInstance(account, httpClentFactory);
                var method = interfaceOfServicetype.GetMethod(nameof(IServicePrices<ResultPriceDto?>.GetPrices));
                if (method is not null)
                {
                    var task = (Task)method.Invoke(accountInstance, null);
                    await task.ConfigureAwait(false);
                    var resultProperty = task.GetType().GetProperty("Result");
                    if (resultProperty is not null)
                    {
                        var taskResult = (ResultPriceDto?)resultProperty.GetValue(task);
                        result.Add(taskResult);
                    }
                }
            });
            return result.ToList();
        }
    }
}
