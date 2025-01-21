using CoffeeShop_APICreation.Models;
using FluentValidation;

namespace CoffeeShop_APICreation.Validator
{
    public class OrderDetailValidator : AbstractValidator<OrderDetailModel>
    {
        public OrderDetailValidator() 
        {
            //RuleFor(c => c.OrderDetailID).NotNull().NotEmpty().WithMessage("OrderDetail ID is required");
            RuleFor(c => c.OrderID).NotNull().NotEmpty().WithMessage("Order ID is required");
            RuleFor(c => c.ProductID).NotNull().NotEmpty().WithMessage("Product ID is required");
            RuleFor(c => c.Quantity).NotNull().NotEmpty().WithMessage("Quantity is required");
            RuleFor(c => c.Amount).NotNull().NotEmpty().WithMessage("Amount is required");
            RuleFor(c => c.TotalAmount).NotNull().NotEmpty().WithMessage("Total Amount is required");
            RuleFor(c => c.UserID).NotNull().NotEmpty().WithMessage("User ID is required");
        }
    }
}
