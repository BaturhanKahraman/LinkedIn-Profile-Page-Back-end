using System.Collections.Generic;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entity.Concrete;
using Entity.Concrete.Dtos;

namespace Business.Abstract
{
    public interface IMemberService
    {
        void Add(Member member);
        List<OperationClaim> GetClaims(User user);
        MemberDetailDto GetByMail(string email);

        IResult GetById(int id);
        public IResult Update(Member member);

        public IResult UpdateProfile(UpdateProfileDto dto);

        public IResult UploadProfilePicture(ProfilePictureDto dto);
    }
}