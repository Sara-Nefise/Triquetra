using AutoMapper;
using MediatR;
using Triquetra.Domain.Data;
using Triquetra.Domain.DTO.Products;

namespace Triquetra.Core.Handlers.Queries.Products
{
    public class GetAllProductsQuery : IRequest<IEnumerable<ProductDTO>>
    {
    }

    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, IEnumerable<ProductDTO>>
    {
        private readonly IUnitOfWork _repository;
        private readonly IMapper _mapper;

        public GetAllProductsQueryHandler(IUnitOfWork repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductDTO>> Handle(GetAllProductsQuery request,
            CancellationToken cancellationToken)
        {
            var entities = await Task.FromResult(_repository.Products.GetAll());
            return _mapper.Map<IEnumerable<ProductDTO>>(entities);
        }
    }
}