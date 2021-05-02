using System;
using System.Linq.Expressions;
using Core.DataAccess;
using Entity.Concrete;
using Entity.Concrete.Dtos;

namespace DataAccess.EntityFramework.Abstract
{
    public interface IMemberDal:IEntityRepository<Member>
    {
        public MemberDetailDto GetMemberDetail(Expression<Func<Member, bool>> filter = null);
    }
}