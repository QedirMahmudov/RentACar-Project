using Core.Entities.Concrete;
using Entities.Concrete;
using FluentValidation;


namespace Business.Validation.FluentValidation
{
    public class UserValidation : AbstractValidator<User>
    {
        public UserValidation()
        {
            //RuleFor(u=>u.UserName).MinimumLength(3).WithMessage("User name less than 3 letters!").MaximumLength(15).WithMessage("User name more than 15 letters!").NotEmpty();
            //RuleFor(u=>u.UserPassword).NotEmpty().WithMessage("Sifre bosdur");
            //RuleFor(u => u.UserPassword)
            //    .NotEmpty().WithMessage("Password cannot be empty!")
            //    .MinimumLength(6).WithMessage("Password must be at least 6 characters long!")
            //    .Matches("[A-Z]").WithMessage("Password must contain at least one uppercase letter!")
            //    .Matches("[a-z]").WithMessage("Password must contain at least one lowercase letter!")
            //    .Matches("[0-9]").WithMessage("Password must contain at least one number!")
            //    .Matches("[^a-zA-Z0-9]").WithMessage("Password must contain at least one special character!");
        }   
    }
}        
