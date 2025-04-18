using ECommerceApi.DTOs;
using FluentValidation;

namespace ECommerceApi.Validators
{
    public class ProductDtoValidator : AbstractValidator<ProductDto>
    {
        public ProductDtoValidator()
        {
            RuleFor(p => p.Name).NotEmpty();                 // Name alanı boş olamaz
            RuleFor(p => p.Price).GreaterThan(0);            // Price alanı 0'dan büyük olmalı
            RuleFor(p => p.Stock).GreaterThanOrEqualTo(0);   // Stock alanı 0 veya daha büyük olamalı
        }
    }
}
