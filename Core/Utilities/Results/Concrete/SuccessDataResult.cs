namespace Core.Utilities.Results.Concrete
{
	public class SuccessDataResult<T> : DataResult<T>
	{
        public SuccessDataResult(T data, string message) : base(data, false, message)
        {

        }
        public SuccessDataResult(T data) : base(data, false)
        {

        }
        public SuccessDataResult() : base(default, false)
        {

        }
        public SuccessDataResult(string message) : base(default, false, message)
        {

        }
    }
}
