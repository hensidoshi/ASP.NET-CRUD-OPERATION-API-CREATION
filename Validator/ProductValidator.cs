using FluentValidation;
using CoffeeShop_APICreation.Models;

namespace CoffeeShop_APICreation.Validator
{
    public class ProductValidator : AbstractValidator<ProductModel>
    {
        public ProductValidator()
        {
            RuleFor(c => c.ProductName).NotNull().NotEmpty().WithMessage("Product Price is required");
            RuleFor(c => c.ProductPrice).NotNull().NotEmpty().WithMessage("Product Name is required");
            RuleFor(c => c.ProductCode).NotNull().NotEmpty().WithMessage("Product Code is required");
            RuleFor(c => c.Description).NotNull().NotEmpty().WithMessage("Description is required");
            RuleFor(c => c.UserID).NotNull().NotEmpty().WithMessage("User ID is required");
        }
    }
}
