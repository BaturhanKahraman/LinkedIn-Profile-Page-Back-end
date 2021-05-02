using System.Collections.Generic;
using Core.DataAccess;
using Entity.Concrete;

namespace DataAccess.EntityFramework.Abstract
{
    public interface ISkillDal:IEntityRepository<Skill>
    {
        void AddRange(List<Skill> skills);

        void RemoveRange(List<Skill> skills);
    }
}