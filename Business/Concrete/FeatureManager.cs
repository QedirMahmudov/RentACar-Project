using Business.Abstract;
using Business.Validation.FluentValidation;
using Core.Aspect.Autofac.Validation.FluentValidation;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
	public class FeatureManager(IFeaturesDal featuresDal) : IFeatureService
	{
		private readonly IFeaturesDal _featuresDal = featuresDal;


		[ValidationAspect<Feature>(typeof(FeatureValidation))]
		public IResult Add(Feature feature)
		{
			_featuresDal.Add(feature);
			return new SuccessResult("Feature was Added!");
		}

		public IResult Delete(int id)
		{
			Feature deleteFeature = null;
			Feature resultFeature = _featuresDal.Get(f => f.Id == id && f.IsActive == true);
			if (resultFeature != null) deleteFeature = resultFeature;
			deleteFeature.IsActive = false;
			_featuresDal.Delete(deleteFeature);
			return new SuccessResult("Feature was deleted!");
		}

		public IDataResult<Feature> Get(int id)
		{
			Feature getFeature = _featuresDal.Get(f => f.Id == id);
			if (getFeature != null)
				return new SuccessDataResult<Feature>(getFeature, "Feature Successfully Loaded!");

			else
				return new ErrorDataResult<Feature>("Feature not found!");
		}

		public IDataResult<List<Feature>> GetAll()
		{
			var getAllFeature = _featuresDal.GetAll(f => f.IsActive == true);
			if (getAllFeature.Count > 0)
				return new SuccessDataResult<List<Feature>>(getAllFeature, "Feature Successfully Loaded!");
			else
				return new ErrorDataResult<List<Feature>>("Feature not found!");
		}

		public IResult Update(Feature feature)
		{
			Feature updateFeature = _featuresDal.Get(f => f.Id == feature.Id && f.IsActive == true);
			if (updateFeature == null)
			{
				return new ErrorResult("Feature not found or is not active.");
			}
			updateFeature.Title = feature.Title;
			updateFeature.Description = feature.Description;
			updateFeature.IconUrl = feature.IconUrl;
			_featuresDal.Update(updateFeature);
			return new SuccessResult("Feature was Update!");
		}
	}
}
