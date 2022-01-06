using MediatR;
using Triquetra.Domain.DTO;
using Triquetra.Domain.Data;
using Triquetra.Core.Exceptions;
using AutoMapper;
using Triquetra.Domain.DTO.Offers;

namespace Triquetra.Providers.Handlers.Queries
{
    public class GetOfferByIdQuery : IRequest<OfferDTO>
    {
        public int OfferId { get; }

        public GetOfferByIdQuery(int offerId)
        {
            OfferId = offerId;
        }
    }

    public class GetOfferByIdQueryHandler : IRequestHandler<GetOfferByIdQuery, OfferDTO>
    {
        private readonly IUnitOfWork _repository;
        private readonly IMapper _mapper;

        public GetOfferByIdQueryHandler(IUnitOfWork repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<OfferDTO> Handle(GetOfferByIdQuery request, CancellationToken cancellationToken)
        {
            var offer = await Task.FromResult(_repository.Offers.Get(request.OfferId));

            if (offer == null)
            {
                throw new EntityNotFoundException($"{request.OfferId} Id'li teklif bulunamadı.");
            }

            return _mapper.Map<OfferDTO>(offer);
        }
    }
}