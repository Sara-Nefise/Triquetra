using Triquetra.Domain.DTO;
using FluentValidation;
using Triquetra.Domain.DTO.Products;

namespace Triquetra.Core.Validators
{
    public class CreateProductValidator : AbstractValidator<CreateProductDTO>
    {
        public CreateProductValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("İsim Boş Bırakılmaz");
            RuleFor(x => x.DollarPrice).GreaterThan(0).WithMessage("Parça fiyatı sıfırdan büyük olmalı");
            RuleFor(x => x.ProductTypeId).GreaterThan(0).WithMessage("Parça türü seçmelisiniz");
        }
    }
}