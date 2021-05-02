using Core.DataAccess;
using Core.Entities.Concrete;

namespace DataAccess.EntityFramework.Abstract
{
    public interface IUserDal:IEntityRepository<User>
    {
        
    }
}