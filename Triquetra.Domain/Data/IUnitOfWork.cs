using Triquetra.Domain.Data.Repositories;

namespace Triquetra.Domain.Data
{
    public interface IUnitOfWork
    {
        IOfferRepository Offers { get; }
        IProductRepository Products { get; }
        IProductTypeRepository ProductTypes { get; }
        IExchangeRateRepository ExchangeRates { get; }
        Task CommitAsync();
    }
}