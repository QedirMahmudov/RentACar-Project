﻿using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
	public interface ICategoryService
	{
		IResult Add(Category category);
		IDataResult<List<Category>> GetAll();
		IResult Delete(int id);
		IResult Update(Category category);
		IDataResult<Category> Get(int id);

	}
}
