using CoffeeShop_APICreation.Models;
using FluentValidation;

namespace CoffeeShop_APICreation.Validator
{
    public class UserValidator : AbstractValidator<UserModel>
    {
        public UserValidator() 
        {
            //RuleFor(c => c.UserID).NotNull().NotEmpty().WithMessage("User ID is required");
            RuleFor(c => c.UserName).NotNull().NotEmpty().WithMessage("User Name is required");
            RuleFor(c => c.Email).NotNull().NotEmpty().WithMessage("Email is required");
            RuleFor(c => c.Password).NotNull().NotEmpty().WithMessage("Password is required");
            RuleFor(c => c.MobileNo).NotNull().NotEmpty().WithMessage("Mobile Number is required");
            RuleFor(c => c.Address).NotNull().NotEmpty().WithMessage("Address is required");
            RuleFor(c => c.IsActive).NotNull().NotEmpty().WithMessage("Is Active is required");
        }
    }
 }
