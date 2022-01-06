using AutoMapper;
using MediatR;
using Triquetra.Domain.Data;
using Triquetra.Domain.DTO.ExchangeRates;

namespace Triquetra.Core.Handlers.Queries.ExchangeRates
{
    public class GetAllExchangeRatesQuery : IRequest<IEnumerable<ExchangeRateDTO>>
    {
    }

    public class
        GetAllExchangeRatesQueryHandler : IRequestHandler<GetAllExchangeRatesQuery, IEnumerable<ExchangeRateDTO>>
    {
        private readonly IUnitOfWork _repository;
        private readonly IMapper _mapper;

        public GetAllExchangeRatesQueryHandler(IUnitOfWork repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ExchangeRateDTO>> Handle(GetAllExchangeRatesQuery request,
            CancellationToken cancellationToken)
        {
            var entities = await Task.FromResult(_repository.ExchangeRates.GetAll());
            return _mapper.Map<IEnumerable<ExchangeRateDTO>>(entities).OrderByDescending(s => s.Date);
        }
    }
}