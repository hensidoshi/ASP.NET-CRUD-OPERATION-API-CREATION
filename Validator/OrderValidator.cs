using CoffeeShop_APICreation.Models;
using FluentValidation;

namespace CoffeeShop_APICreation.Validator
{
    public class OrderValidator : AbstractValidator<OrderModel>
    {
        public OrderValidator() 
        {
            //RuleFor(c => c.OrderID).NotNull().NotEmpty().WithMessage("Order ID is required");
            RuleFor(c => c.OrderDate).NotNull().NotEmpty().WithMessage("Order Date is required");
            RuleFor(c => c.OrderNumber).NotNull().NotEmpty().WithMessage("Order Number is required");
            RuleFor(c => c.CustomerID).NotNull().NotEmpty().WithMessage("Customer ID is required");
            RuleFor(c => c.PaymentMode).NotNull().NotEmpty().WithMessage("Payment Mode is required");
            RuleFor(c => c.TotalAmount).NotNull().NotEmpty().WithMessage("Total Amount is required");
            RuleFor(c => c.ShippingAddress).NotNull().NotEmpty().WithMessage("Shipping Address is required");
            RuleFor(c => c.UserID).NotNull().NotEmpty().WithMessage("User ID is required");
        }
    }
}
