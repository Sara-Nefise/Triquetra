using AutoMapper;
using MediatR;
using Triquetra.Domain.Data;
using Triquetra.Domain.DTO.ProductTypes;

namespace Triquetra.Core.Handlers.Queries.ProductTypes
{
    public class GetAllProductTypesQuery : IRequest<IEnumerable<ProductTypeDTO>>
    {
    }

    public class GetAllProductTypesQueryHandler : IRequestHandler<GetAllProductTypesQuery, IEnumerable<ProductTypeDTO>>
    {
        private readonly IUnitOfWork _repository;
        private readonly IMapper _mapper;

        public GetAllProductTypesQueryHandler(IUnitOfWork repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductTypeDTO>> Handle(GetAllProductTypesQuery request,
            CancellationToken cancellationToken)
        {
            var entities = await Task.FromResult(_repository.ProductTypes.GetAll());
            return _mapper.Map<IEnumerable<ProductTypeDTO>>(entities);
        }
    }
}