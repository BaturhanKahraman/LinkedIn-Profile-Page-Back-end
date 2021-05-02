using Core.Entities;

namespace Entity.Concrete.Dtos
{
    public class UserForLoginDto:IDto
    {
        public string Email { get; set; }

        public string Password { get; set; }
    }
}