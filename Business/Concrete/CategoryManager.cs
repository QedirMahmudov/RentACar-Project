using Business.Abstract;
using Business.Validation.FluentValidation;
using Core.Aspect.Autofac.Validation.FluentValidation;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;

namespace Business.Concrete
{
	public class CategoryManager(ICategoryDal categoryDal) : ICategoryService
	{
		private readonly ICategoryDal _categoryDal = categoryDal;

		[ValidationAspect<Category>(typeof(CategoryValidation))]

		public IResult Add(Category category)
		{
			_categoryDal.Add(category);
			return new SuccessResult("Category was Added!");
		}

		public IResult Delete(int id)
		{
			Category deleteCategory = null;
			Category resultCategory = _categoryDal.Get(C => C.Id == id && C.IsActive == true);
			if (resultCategory != null) 
				deleteCategory = resultCategory;
			deleteCategory.IsActive = false;
			_categoryDal.Delete(deleteCategory);
			return new SuccessResult("Category was deleted!");
		}

		public IDataResult<Category> Get(int id)
		{
			Category getCategory = _categoryDal.Get(C => C.Id == id);
			if (getCategory != null)
				return new SuccessDataResult<Category>(getCategory, "Category Successfully Loaded!");
			else
				return new ErrorDataResult<Category>("Car not found!");
		}
		public IDataResult<List<Category>> GetAll()
		{
			var getAllCategories = _categoryDal.GetAll(c => c.IsActive == true);
			if (getAllCategories.Count > 0)
				return new SuccessDataResult<List<Category>>(getAllCategories, "Category Successfully Loaded!");
			else
				return new ErrorDataResult<List<Category>>("Category not found!");
		}

		public IResult Update(Category category)
		{
			Category updateCategory = _categoryDal.Get(C=>C.Id == category.Id && C.IsActive == true);
			if (updateCategory == null)
			{
				return new ErrorResult("Category not found or is not active.");
			}
			updateCategory.CategoryName = category.CategoryName;
			_categoryDal.Update(updateCategory);
			return new SuccessResult("Category was Update!");
		}
	}
}
