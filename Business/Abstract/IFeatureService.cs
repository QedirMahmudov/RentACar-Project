using Core.Utilities.Results.Abstract;
using Entities.Concrete;



namespace Business.Abstract
{
	public interface IFeatureService
	{
		IResult Add(Feature feature);
		IResult Update(Feature feature);
		IResult Delete(int id);
		IDataResult<Feature> Get(int id);
		IDataResult<List<Feature>> GetAll();

	}
}
