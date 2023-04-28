using Domain.Dtos;

namespace Data.Contracts
{
    public interface IServicePrices<T>
    {
        Task<T> GetPrices();
    }
    public interface IPriceAccessWrapperRepository
    {
        Task<List<ResultPriceDto?>> GetPrices(CancellationToken cancellationToken);
    }
}
