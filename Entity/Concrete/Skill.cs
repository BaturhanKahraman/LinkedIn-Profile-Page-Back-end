using Core.Entities;

namespace Entity.Concrete
{
    public class Skill:IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int MemberId { get; set; }
        public Member Member { get; set; }
    }
}