using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.EntityFramework.Abstract;
using Entity.Concrete;

namespace Business.Concrete
{
    public class EducationManager:IEducationService
    {
        private readonly IEducationDal _educationDal;
        public EducationManager(IEducationDal educationDal)
        {
            _educationDal = educationDal;
        }
        public IResult Add(Education education)
        {
            _educationDal.Add(education);
            return new SuccessResult(Messages.EducationAdded);
        }

        public IResult Update(Education education)
        {
            _educationDal.Update(education);
            return new SuccessResult(Messages.EducationUpdated);
        }

        public IResult Delete(Education education)
        {
            _educationDal.Delete(education);
            return new SuccessResult(Messages.EducationDeleted);
        }
    }
}