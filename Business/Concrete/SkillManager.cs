using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.EntityFramework.Abstract;
using Entity.Concrete;

namespace Business.Concrete
{
    public class SkillManager:ISkillService
    {
        private readonly ISkillDal _skillDal;
        private readonly IMemberService _memberService;

        public SkillManager(ISkillDal skillDal, IMemberService memberService)
        {
            _skillDal = skillDal;
            _memberService = memberService;
        }

        public IResult Add(Skill skill)
        {
            _skillDal.Add(skill);
            return new SuccessResult();
        }

        public IResult AddRange(List<Skill> skills)
        {
            skills.ForEach(s=> s.Id = 0);
            int memberId = skills.FirstOrDefault().MemberId;
            var skillsToDelete = _skillDal.GetList(x => x.MemberId == memberId).ToList();
            _skillDal.RemoveRange(skillsToDelete);
            _skillDal.AddRange(skills.Distinct().ToList());
            return new SuccessResult(Messages.SkillsAdded);
        }
    }
}