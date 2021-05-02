using Core.Entities;

namespace Entity.Concrete.Dtos
{
    public class UpdateProfileDto:IDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string CurrentPlace { get; set; }
        public string Degree { get; set; }

        public string About { get; set; }
    }
}