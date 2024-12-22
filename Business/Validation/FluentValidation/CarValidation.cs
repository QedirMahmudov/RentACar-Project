using Entities.Concrete;
using FluentValidation;

namespace Business.Validation.FluentValidation
{
	public class CarValidation : AbstractValidator<Car>
	{
		public CarValidation()
		{
			RuleFor(c => c.CarBrand).MinimumLength(3).WithMessage("Car name less than 3 letters!").NotNull().WithMessage("Car name is empty!");
			RuleFor(c => c.CarModel).NotNull().WithMessage("Car model is empty!");
			RuleFor(c => c.CarPrice).Must(carPrice => carPrice.ToString().Length <= 8).WithMessage("Price is too high!");
			RuleFor(c => c.Description).MaximumLength(1000).WithMessage("Filled the writing space,Please shorten your description!");
			RuleFor(c => (int)c.CarYear).InclusiveBetween(2015, DateTime.Now.Year).WithMessage("CarYear must be between 2015 and current year.");
		}
	}
}
