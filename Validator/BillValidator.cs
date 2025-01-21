using CoffeeShop_APICreation.Models;
using FluentValidation;

namespace CoffeeShop_APICreation.Validator
{
    public class BillValidator : AbstractValidator<BillModel>
    {
        public BillValidator() 
        {
            //RuleFor(c => c.BillID).NotNull().NotEmpty().WithMessage("Bill ID is required");
            RuleFor(c => c.BillNumber).NotNull().NotEmpty().WithMessage("Bill Number is required");
            RuleFor(c => c.BillDate).NotNull().NotEmpty().WithMessage("Bill Date is required");
            RuleFor(c => c.OrderID).NotNull().NotEmpty().WithMessage("Order ID is required");
            RuleFor(c => c.TotalAmount).NotNull().NotEmpty().WithMessage("Total Amount is required");
            RuleFor(c => c.Discount).NotNull().NotEmpty().WithMessage("Discount is required");
            RuleFor(c => c.NetAmount).NotNull().NotEmpty().WithMessage("Net Amount is required");
            RuleFor(c => c.UserID).NotNull().NotEmpty().WithMessage("User ID is required");
        }
    }
}
