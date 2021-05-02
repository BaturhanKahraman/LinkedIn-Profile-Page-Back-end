using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.EntityFramework.Abstract;
using Entity.Concrete;

namespace Business.Concrete
{
    public class ExperienceManager:IExperienceService
    {
        private readonly IExperienceDal _experienceDal;

        public ExperienceManager(IExperienceDal experienceDal)
        {
            _experienceDal = experienceDal;
        }

        public IResult Add(Experience exp)
        {
            _experienceDal.Add(exp);
            return new SuccessResult(Messages.ExperienceAdded);
        }

        public IResult Update(Experience exp)
        {
            _experienceDal.Update(exp);
            return new SuccessResult(Messages.ExperienceUpdated);
        }

        public IResult Delete(Experience exp)
        {
            _experienceDal.Delete(exp);
            return new SuccessResult(Messages.ExperienceDeleted);
        }
    }
}