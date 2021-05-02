using Core.Utilities.Results;
using Entity.Concrete.Dtos;

namespace Business.Abstract
{
    public interface IAuthService
    {
        IResult Login(UserForLoginDto dto);

        IResult SignUp(UserForRegisterDto dto);
    }
}