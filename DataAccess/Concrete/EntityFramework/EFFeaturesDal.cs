using Core.DataAccess.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
	public class EFFeaturesDal : EFEntityRepository<Feature, RentACarContext>, IFeaturesDal
	{
		public EFFeaturesDal(RentACarContext context) : base(context)
		{
		}
	}
}
