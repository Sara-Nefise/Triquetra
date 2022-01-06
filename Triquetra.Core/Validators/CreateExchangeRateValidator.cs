using FluentValidation;
using Triquetra.Domain.DTO.ExchangeRates;

namespace Triquetra.Core.Validators
{
    public class ExchangeRateValidator : AbstractValidator<CreateExchangeRateDTO>
    {
        public ExchangeRateValidator()
        {
            RuleFor(x => x.Amount).GreaterThan(0).WithMessage("Miktar sıfırdan büyük olmalı");
            RuleFor(x => x.Date).NotNull().WithMessage("Tarih değeri girmelisiniz");
        }
    }
}
