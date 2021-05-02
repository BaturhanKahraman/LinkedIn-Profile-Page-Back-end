using Core.Utilities.Results;
using Entity.Concrete;

namespace Business.Abstract
{
    public interface IExperienceService
    {
        public IResult Add(Experience exp);
        IResult Update(Experience exp);
        IResult Delete(Experience exp);
    }
}