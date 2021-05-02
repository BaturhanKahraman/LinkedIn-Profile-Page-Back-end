using System;
using System.Linq;
using System.Linq.Expressions;
using Castle.DynamicProxy.Generators.Emitters.SimpleAST;
using Core.DataAccess;
using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.EntityFramework.Abstract;
using DataAccess.EntityFramework.Context;
using Entity.Concrete;
using Entity.Concrete.Dtos;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.EntityFramework.Concrete
{
    public class EfMemberDal : EfEntityRepositoryBase<Member, LinkedInContext>, IMemberDal
    {
        public MemberDetailDto GetMemberDetail(Expression<Func<Member, bool>> filter = null)
        {
            using var context = new LinkedInContext();
            var members = filter == null ? context.Members : context.Members.Where(filter);
            return members.Include(m => m.User)
                .Include(m => m.Experiences)
                .Include(m => m.Educations)
                .Include(m => m.Skills)
                .Select(m => new MemberDetailDto()
                {
                    Email = m.User.Email,
                    Experiences = m.Experiences,
                    CurrentPlace = m.CurrentPlace,
                    Educations = m.Educations,
                    About = m.About,
                    Degree = m.Degree,
                    FirstName = m.User.FirstName,
                    Id = m.Id,
                    Skills = m.Skills,
                    LastName = m.User.LastName,
                    ProfilePower = m.ProfilePower,
                    UserId = m.UserId,
                    View = m.View,
                    ProfilePicturePath = m.ProfilePicturePath,
                    PasswordHash = m.User.PasswordHash,
                     PasswordSalt = m.User.PasswordSalt
                })
                .FirstOrDefault();
        }
    }
}