using System.Collections.Generic;
using Core.Utilities.Results;
using Entity.Concrete;

namespace Business.Abstract
{
    public interface ISkillService
    {
        public IResult Add(Skill skill);
        IResult AddRange(List<Skill> skills);
    }
}