using Business.Abstract;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class TestimonialManager(ITestimonialDal testimonialDal) : ITestimonialService
    {
        private readonly ITestimonialDal _testimonialDal;
        public IResult Add(Testimonial testimonial)
        {
            _testimonialDal.Add(testimonial);
            return new SuccessResult("Testimonial was Added!");
        }

        public IResult Delete(int id)
        {
            Testimonial deleteTestimonial = null;
            Testimonial resultTestimonial = _testimonialDal.Get(T => T.Id == id && T.IsActive == true);
            if (resultTestimonial != null)
                deleteTestimonial = resultTestimonial;
            deleteTestimonial.IsActive = false;
            _testimonialDal.Delete(deleteTestimonial);
            return new SuccessResult("Testimonial was deleted!");
        }

        public IDataResult<Testimonial> Get(int id)
        {
            Testimonial getTestimonial = _testimonialDal.Get(T => T.Id == id);
            if (getTestimonial != null)
                return new SuccessDataResult<Testimonial>(getTestimonial, "Testimonial Successfully Loaded!");
            else
                return new ErrorDataResult<Testimonial>("Testimonial not found!");
        }
        public IDataResult<List<Testimonial>> GetAll()
        {
            var getAllTestimonials = _testimonialDal.GetAll(T => T.IsActive == true);
            if (getAllTestimonials.Count > 0)
                return new SuccessDataResult<List<Testimonial>>(getAllTestimonials, "Testimonial Successfully Loaded!");
            else
                return new ErrorDataResult<List<Testimonial>>("Testimonial not found!");
        }

        public IResult Update(Testimonial testimonial)
        {
            Testimonial updateTestimonial = _testimonialDal.Get(T => T.Id == testimonial.Id && T.IsActive == true);
            if (updateTestimonial == null)
            {
                return new ErrorResult("Testimonial not found or is not active.");
            }
            updateTestimonial.TestimonialFullName = testimonial.TestimonialFullName;
            updateTestimonial.TestimonialComment = testimonial.TestimonialComment;
            updateTestimonial.TestimonialPosition = testimonial.TestimonialPosition;
            _testimonialDal.Update(updateTestimonial);
            return new SuccessResult("Testimonial was Update!");
        }
    }
}
