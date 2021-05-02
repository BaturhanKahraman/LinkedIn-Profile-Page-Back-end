using Core.Utilities.Results;
using Entity.Concrete;

namespace Business.Abstract
{
    public interface IEducationService
    {
        IResult Add(Education education);
        IResult Update(Education education);
        IResult Delete(Education education);
    }
}