using System.Collections.Generic;
using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.FileUpload;
using Core.Utilities.Results;
using DataAccess.EntityFramework.Abstract;
using Entity.Concrete;
using Entity.Concrete.Dtos;

namespace Business.Concrete
{
    public class MemberManager:IMemberService
    {
        private readonly IMemberDal _memberDal;
        private readonly IUserService _userService;

        public MemberManager(IMemberDal memberDal, IUserService userService)
        {
            _memberDal = memberDal;
            _userService = userService;
        }

        public void Add(Member member)
        {
            _memberDal.Add(member);
        }

        public List<OperationClaim> GetClaims(User user)
        {
            throw new System.NotImplementedException();
        }

        public MemberDetailDto GetByMail(string email)
        {
            return _memberDal.GetMemberDetail(m => m.User.Email == email);
        }

        public IResult GetById(int id)
        {
            var member = _memberDal.GetMemberDetail(m => m.Id == id);
            return new SuccessDataResult<MemberDetailDto>(member);
        }

        public IResult Update(Member member)
        {
            _memberDal.Update(member);
            return new SuccessResult();
        }

        public IResult UpdateProfile(UpdateProfileDto dto)
        {
            var member = _memberDal.Get(m => m.Id == dto.Id);
            member.About = dto.About;
            member.CurrentPlace = dto.CurrentPlace;
            member.Degree = dto.Degree;
            _memberDal.Update(member);
            var user = _userService.GetById(member.UserId);
            user.FirstName = dto.Name;
            user.LastName = dto.Surname;
            _userService.Update(user);
            return new SuccessResult(Messages.UserUpdated);
        }

        public IResult UploadProfilePicture(ProfilePictureDto dto)
        {
            var result = FileUpload.Upload(dto.Image);
            if (!result.Success)
                return new ErrorResult(result.Message);
            var member =_memberDal.Get(x => x.Id == dto.MemberId);
            member.ProfilePicturePath = ((SuccessDataResult<string>) result).Data;
            _memberDal.Update(member);
            return new SuccessResult(Messages.ProfilePictureUpdated);
        }
    }
}