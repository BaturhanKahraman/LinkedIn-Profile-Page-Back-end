using Core.Entities;

namespace Entity.Concrete.Dtos
{
    public class UserForRegisterDto:IDto
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public string Name { get; set; }

        public string Lastname { get; set; }
    }
}