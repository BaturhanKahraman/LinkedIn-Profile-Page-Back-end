using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.EntityFramework.Abstract;
using DataAccess.EntityFramework.Context;

namespace DataAccess.EntityFramework.Concrete
{
    public class EfUserDal:EfEntityRepositoryBase<User,LinkedInContext>,IUserDal
    {
        
    }
}