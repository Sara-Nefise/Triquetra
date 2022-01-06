using FluentValidation;
using MediatR;
using Triquetra.Core.Exceptions;
using Triquetra.Domain.Data;
using Triquetra.Domain.Data.Entities;
using Triquetra.Domain.DTO.ExchangeRates;

namespace Triquetra.Core.Handlers.Commands
{
    public class CreateExchangeRateCommand : IRequest<int>
    {
        public CreateExchangeRateDTO Model { get; }

        public CreateExchangeRateCommand(CreateExchangeRateDTO model)
        {
            Model = model;
        }
    }

    public class CreateExchangeRateCommandHandler : IRequestHandler<CreateExchangeRateCommand, int>
    {
        private readonly IUnitOfWork _repository;
        private readonly IValidator<CreateExchangeRateDTO> _validator;

        public CreateExchangeRateCommandHandler(IUnitOfWork repository, IValidator<CreateExchangeRateDTO> validator)
        {
            _repository = repository;
            _validator = validator;
        }

        public async Task<int> Handle(CreateExchangeRateCommand request, CancellationToken cancellationToken)
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

            var entity = new ExchangeRate
            {
                Amount = model.Amount,
                Date = model.Date,
            };

            _repository.ExchangeRates.Add(entity);
            await _repository.CommitAsync();

            return entity.Id;
        }
    }
}