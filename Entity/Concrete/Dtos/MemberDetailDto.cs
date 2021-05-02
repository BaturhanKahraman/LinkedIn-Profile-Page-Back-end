using System.Collections.Generic;
using Core.Entities;

namespace Entity.Concrete.Dtos
{
    public class MemberDetailDto : IDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }

        public string CurrentPlace { get; set; }
        public byte[] PasswordSalt { get; set; }
        public byte[] PasswordHash { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Degree { get; set; }
        public string About { get; set; }
        public int ProfilePower { get; set; }
        public string ProfilePicturePath { get; set; }
        public int View { get; set; }

        public List<Experience> Experiences { get; set; } = new();

        public List<Education> Educations { get; set; } = new();

        public List<Skill> Skills { get; set; } = new();
    }
}