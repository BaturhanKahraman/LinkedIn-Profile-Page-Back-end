using Core.DataAccess;
using Core.DataAccess.EntityFramework;
using DataAccess.EntityFramework.Abstract;
using DataAccess.EntityFramework.Context;
using Entity.Concrete;

namespace DataAccess.EntityFramework.Concrete
{
    public class EfExperienceDal:EfEntityRepositoryBase<Experience,LinkedInContext>,IExperienceDal
    {
        
    }
}