using System.Runtime.InteropServices.ComTypes;
using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Business;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.Jwt;
using Entity.Concrete;
using Entity.Concrete.Dtos;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private readonly IMemberService _memberService;
        private readonly ITokenHelper _tokenHelper;
        private readonly IUserService _userService;
        public AuthManager(IMemberService memberService, ITokenHelper tokenHelper, IUserService userService)
        {
            _memberService = memberService;
            _tokenHelper = tokenHelper;
            _userService = userService;
        }

        public IResult Login(UserForLoginDto dto)
        {
            var member = _memberService.GetByMail(dto.Email);
            if (member == null)
            {
                return new ErrorResult(Messages.UserDoesntExists);
            }
            if (!HashingHelper.VerifyPasswordHash(dto.Password, member.PasswordHash, member.PasswordSalt))
            {
                return new ErrorResult(Messages.UserDoesntExists);
            }
            return new SuccessDataResult<MemberDetailDto>(member);
        }

        public IResult SignUp(UserForRegisterDto dto)
        {
            HashingHelper.CreatePasswordHash(dto.Password, out var passwordHash, out var passwordSalt);
            var user = new User()
            {
                Email = dto.Email,
                FirstName = dto.Name,
                LastName = dto.Lastname,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true
            };
            var result = _userService.Add(user);
            if (!result.Success)
                return result;
            var member = new Member()
            {
                User  = user
            };
            _memberService.Add(member);

            return new SuccessResult(Messages.UserAdded);
        }

        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            var claims = _memberService.GetClaims(user);
            var accessToken = _tokenHelper.CreateToken(user, claims);
            return new SuccessDataResult<AccessToken>(accessToken);
        }
    }
}