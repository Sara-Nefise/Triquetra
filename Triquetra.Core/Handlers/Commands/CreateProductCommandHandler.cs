using FluentValidation;
using MediatR;
using Triquetra.Core.Exceptions;
using Triquetra.Domain.Data;
using Triquetra.Domain.Data.Entities;
using Triquetra.Domain.DTO.Products;

namespace Triquetra.Core.Handlers.Commands
{
    public class CreateProductCommand : IRequest<int>
    {
        public CreateProductDTO Model { get; }

        public CreateProductCommand(CreateProductDTO model)
        {
            Model = model;
        }
    }

    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, int>
    {
        private readonly IUnitOfWork _repository;
        private readonly IValidator<CreateProductDTO> _validator;

        public CreateProductCommandHandler(IUnitOfWork repository, IValidator<CreateProductDTO> validator)
        {
            _repository = repository;
            _validator = validator;
        }

        public async Task<int> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var model = request.Model;

            var result = await _validator.ValidateAsync(model, cancellationToken);

            if (!result.IsValid)
            {
                var errors = result.Errors.Select(x => x.ErrorMessage).ToArray();
                throw new InvalidRequestBodyException
                {
                    Errors = errors
                };
            }

            var entity = new Product
            {
                Name = model.Name,
                Size = model.Size,
                DollarPrice = model.DollarPrice,
                ProductTypeId = model.ProductTypeId
            };

            _repository.Products.Add(entity);
            await _repository.CommitAsync();

            return entity.Id;
        }
    }
}