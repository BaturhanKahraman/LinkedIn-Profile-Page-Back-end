using System.Collections.Generic;
using Core.DataAccess.EntityFramework;
using DataAccess.EntityFramework.Abstract;
using DataAccess.EntityFramework.Context;
using Entity.Concrete;

namespace DataAccess.EntityFramework.Concrete
{
    public class EfSkillDal:EfEntityRepositoryBase<Skill,LinkedInContext>,ISkillDal
    {
        public void AddRange(List<Skill> skills)
        {
            using var db = new LinkedInContext();
            db.AddRange(skills);
            db.SaveChanges();
        }

        public void RemoveRange(List<Skill> skills)
        {
            using var db = new LinkedInContext();
            db.RemoveRange(skills);
            db.SaveChanges();
        }
    }
}