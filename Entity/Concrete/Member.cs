using System.Collections.Generic;
using System.Security.AccessControl;
using Core.Entities;
using Core.Entities.Concrete;

namespace Entity.Concrete
{
    public class Member:IEntity
    {
        
        public int Id { get; set; }
        public  int UserId { get; set; }
        public User User { get; set; }
        public string CurrentPlace { get; set; }

        public string Degree { get; set; }
        public string About { get; set; }
        public int ProfilePower { get; set; }

        public int View { get; set; }

        public string ProfilePicturePath { get; set; }

        public  List<Experience> Experiences { get; set; } = new List<Experience>();

        public  List<Education> Educations { get; set; } = new List<Education>();

        public  List<Skill> Skills { get; set; } = new List<Skill>();

    }
}
