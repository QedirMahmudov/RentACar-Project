﻿using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Interceptors
{
	public class AspectInterceptorSelector : IInterceptorSelector
	{
		//Type - [Validation(typeof)]
		//MethodInfo - add,update,delete
		public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
		{
			var classAttributes = type.GetCustomAttributes<MethodInterceptorBaseAttribute>
				 (true).ToList();
			var methodAttributes = type.GetMethod(method.Name)
				.GetCustomAttributes<MethodInterceptorBaseAttribute>(true);
			classAttributes.AddRange(methodAttributes);
			return classAttributes.OrderBy(x => x.Priority).ToArray();
		}
	}
}
