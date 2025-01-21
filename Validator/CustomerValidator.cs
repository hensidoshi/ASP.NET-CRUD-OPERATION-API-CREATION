using CoffeeShop_APICreation.Models;
using FluentValidation;

namespace CoffeeShop_APICreation.Validator
{
    public class CustomerValidator : AbstractValidator<CustomerModel>
    {
        public CustomerValidator()
        {
            //RuleFor(c => c.CustomerID).NotNull().NotEmpty().WithMessage("Customer ID is required");
            RuleFor(c => c.CustomerName).NotNull().NotEmpty().WithMessage("Customer Name is required");
            RuleFor(c => c.HomeAddress).NotNull().NotEmpty().WithMessage("Home Address is required");
            RuleFor(c => c.Email).NotNull().NotEmpty().WithMessage("Email is required");
            RuleFor(c => c.MobileNo).NotNull().NotEmpty().WithMessage("Mobile Number is required");
            RuleFor(c => c.GST_NO).NotNull().NotEmpty().WithMessage("GST Number is required");
            RuleFor(c => c.CityName).NotNull().NotEmpty().WithMessage("City Name is required");
            RuleFor(c => c.Pincode).NotNull().NotEmpty().WithMessage("Pincode is required");
            RuleFor(c => c.NetAmount).NotNull().NotEmpty().WithMessage("Net Amount is required");
            RuleFor(c => c.UserID).NotNull().NotEmpty().WithMessage("User ID is required");
        }
    }
}
