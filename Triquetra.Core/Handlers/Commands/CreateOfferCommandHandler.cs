using FluentValidation;
using MediatR;
using Triquetra.Core.Exceptions;
using Triquetra.Domain.Data;
using Triquetra.Domain.Data.Entities;
using Triquetra.Domain.DTO.Offers;

namespace Triquetra.Core.Handlers.Commands
{
    public class CreateOfferCommand : IRequest<int>
    {
        public int Id { get; set; }
        public CreateOfferDTO Model { get; }

        public CreateOfferCommand(CreateOfferDTO model)
        {
            Model = model;
        }
    }

    public class CreateOfferCommandHandler : IRequestHandler<CreateOfferCommand, int>
    {
        private readonly IUnitOfWork _repository;
        private readonly IValidator<CreateOfferDTO> _validator;

        public CreateOfferCommandHandler(IUnitOfWork repository, IValidator<CreateOfferDTO> validator)
        {
            _repository = repository;
            _validator = validator;
        }

        public async Task<int> Handle(CreateOfferCommand request, CancellationToken cancellationToken)
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

            if (model.Id > 0)
            {
                var offer = await Task.FromResult(_repository.Offers.Get(request.Model.Id));
                offer.DiscountRate = model.DiscountRate;
                offer.DiscountedPriceTL = model.TotalPriceTL - model.TotalPriceTL * model.DiscountRate / 100;
                _repository.Offers.Update(offer);
                await _repository.CommitAsync();

            }
            else
            {
                var entity = new Offer
                {
                    SetupArea = model.SetupArea,
                    PanelCount = model.PanelCount,
                    InverterCount = model.InverterCount,
                    TotalPriceDollar = model.TotalPriceDollar,
                    TotalPriceTL = model.TotalPriceTL,
                    DiscountRate = model.DiscountRate,
                    DiscountedPriceTL = model.DiscountedPriceTL
                };

                _repository.Offers.Add(entity);
                await _repository.CommitAsync();
                request.Id = entity.Id;
            }

            return request.Id;
        }
    }
}