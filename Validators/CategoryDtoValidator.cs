using ECommerceApi.Entities;
using FluentValidation;

namespace ECommerceApi.Validators
{
    public class CategoryDtoValidator : AbstractValidator<Category>
    {
        public CategoryDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .MinimumLength(3)
                .WithMessage("Kategori adı en az 3 karekter olmalıdır.");
        }
    }
}
