using FluentValidation;


namespace Business.Features.Products.Commands.Create
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(i => i.Name).NotEmpty().WithMessage("İsim alanı boş olamaz.");
            RuleFor(i => i.Stock).GreaterThanOrEqualTo(1);
            RuleFor(i => i.UnitPrice).GreaterThanOrEqualTo(1);
            RuleFor(i=> i.CategoryId).GreaterThanOrEqualTo(1);

            // Kendi kuralımız.
            RuleFor(i => i.Name).Must(StartsWithA).WithMessage("İsim alanı a harfi ile başlamalıdır.");
        }

        public bool StartsWithA(string name)
        {
            return name.StartsWith("A");
        }
    }
}
