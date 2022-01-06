using AutoMapper;
using MediatR;
using Triquetra.Domain.Data;
using Triquetra.Domain.DTO.Offers;

namespace Triquetra.Core.Handlers.Queries.Offers
{
    public class GetAllOffersQuery : IRequest<IEnumerable<OfferDTO>>
    {
    }

    public class GetAllOffersQueryHandler : IRequestHandler<GetAllOffersQuery, IEnumerable<OfferDTO>>
    {
        private readonly IUnitOfWork _repository;
        private readonly IMapper _mapper;

        public GetAllOffersQueryHandler(IUnitOfWork repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<OfferDTO>> Handle(GetAllOffersQuery request, CancellationToken cancellationToken)
        {
            var entities = await Task.FromResult(_repository.Offers.GetAll());
            return _mapper.Map<IEnumerable<OfferDTO>>(entities).OrderByDescending(s => s.AddedOn);
        }
    }
}