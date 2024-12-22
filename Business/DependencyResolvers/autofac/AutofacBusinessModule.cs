using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Business;
using Core.Utilities.Interceptors;
using Core.Utilities.Security.JWT;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DependencyResolvers.autofac
{
    public class AutofacBusinessModule : Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			builder.RegisterType<CarManager>().As<ICarService>().SingleInstance();
			builder.RegisterType<EFCarDal>().As<ICarDal>().SingleInstance();
			builder.RegisterType<CategoryManager>().As<ICategoryService>().SingleInstance();
			builder.RegisterType<EFCategoryDal>().As<ICategoryDal>().SingleInstance();
            builder.RegisterType<EFCarImageDal>().As<ICarImageDal>().SingleInstance();
            //builder.RegisterType<CarImageManager>().As<ICarImageService>().SingleInstance();
            builder.RegisterType<TestimonialManager>().As<ITestimonialService>();
            builder.RegisterType<EFTestimonialDal>().As<ITestimonialDal>();
            builder.RegisterType<UserManager>().As<IUserService>();
            builder.RegisterType<EfUserDal>().As<IUserDal>();
            builder.RegisterType<UserManager>().As<IUserService>().SingleInstance();
            builder.RegisterType<AuthManager>().As<IAuthService>().SingleInstance();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>().SingleInstance();

            builder.RegisterType<RentACarContext>().As<RentACarContext>().SingleInstance();
            builder.RegisterType<AddPhotoHelper>().As<IAddPhotoHelperService>().SingleInstance();




            var assembly = System.Reflection.Assembly.GetExecutingAssembly();
			builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
				.EnableInterfaceInterceptors(new ProxyGenerationOptions()
				{
					Selector = new AspectInterceptorSelector()
				}).SingleInstance();
		}
	}
}
