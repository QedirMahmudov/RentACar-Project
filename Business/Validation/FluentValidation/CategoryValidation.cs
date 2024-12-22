using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validation.FluentValidation
{
	public class CategoryValidation : AbstractValidator<Category>
	{
        public CategoryValidation()
        {
			RuleFor(C => C.CategoryName).MinimumLength(3).WithMessage("Category name less than 3 letters!").NotNull().WithMessage("Category name is empty!");
		}
	}
}
