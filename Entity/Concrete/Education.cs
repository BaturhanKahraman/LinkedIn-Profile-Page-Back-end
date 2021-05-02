using System;
using Core.Entities;

namespace Entity.Concrete
{
    public class Education:IEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public string Subtitle { get; set; }
        public string Place { get; set; }
        public DateTime StartedDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string City { get; set; }

        public int MemberId { get; set; }
        public Member Member { get; set; }
    }
}