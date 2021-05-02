using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.EntityFramework.Abstract;

namespace Business.Concrete
{
    public class UserManager:IUserService
    {
        private readonly IUserDal _userDal;
        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IResult Add(User user)
        {
            var result =BusinessRules.Run(this.UserExistsForAdd(user.Email));
            if (result!=null)
            {
                return result;
            }
            _userDal.Add(user);
            return new SuccessResult(Messages.UserAdded);
        }

        public User GetById(int userId)
        {
            return _userDal.Get(u => u.Id == userId);
        }

        public void Update(User user)
        {
            _userDal.Update(user);
        }

        private IResult UserExistsForAdd(string email)
        {
            var user = _userDal.Get(x => x.Email == email);
            if (user!=null)
            {
                return new ErrorResult(Messages.UserAlreadyExists);
            }
            return new SuccessResult();
        }
    }
}