using System;
using System.Security.AccessControl;
using Core.Entities;

namespace Entity.Concrete
{
    public class Experience:IEntity
    {   
        public int Id { get; set; }
        public string Title { get; set; }
        public string Place { get; set; }
        public DateTime StartedDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string City { get; set; }

        public int MemberId { get; set; }
        public Member Member { get; set; }
    }
}